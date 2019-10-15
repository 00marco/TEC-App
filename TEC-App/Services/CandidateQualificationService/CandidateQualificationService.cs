﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.CandidateQualificationService
{
    public class CandidateQualificationService : ICandidateQualificationService
    {
        public readonly TecAppContext context;

        public CandidateQualificationService(TecAppContext context)
        {
            this.context = context;
        }
        public List<Candidate_Qualification> GetAll()
        {
            return context.Set<Candidate_Qualification>()
                .Include(d => d.Candidate)
                .Include(d => d.Qualification)
                .ToList();
        }

        public Candidate_Qualification AddQualificationToCandidate(Candidate_Qualification candidateQualification)
        {
            context.Candidate_Qualification_Pairs.Add(candidateQualification);
            context.SaveChanges();
            return candidateQualification;
        }

        public Candidate_Qualification GetFromIdPair(int candidateId, int qualificationId)
        {
            var ret = GetAll().FirstOrDefault(d => d.CandidateId == candidateId && d.QualificationId == qualificationId);
            if (ret == null)
            {
                return new Candidate_Qualification()
                {
                    Id = -1
                };
            }

            return ret;

        }

        public void RemoveQualificationFromCandidate(int candidateId, int qualificationId)
        {
            context.Remove(GetFromIdPair(candidateId, qualificationId));
            context.SaveChanges();

        }
    }
}