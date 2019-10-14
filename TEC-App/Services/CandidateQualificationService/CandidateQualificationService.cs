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

        public Candidate_Qualification Add(Candidate_Qualification candidateQualification)
        {
            context.Candidate_Qualification_Pairs.Add(candidateQualification);
            context.SaveChanges();
            return candidateQualification;
        }

        public Candidate_Qualification GetFromIdPair(int candidateId, int qualificationId)
        {
            return GetAll().Single(d => d.CandidateId == candidateId && d.QualificationId == qualificationId);

        }

        public void Remove(int candidateId, int qualificationId)
        {
            context.Remove(GetFromIdPair(candidateId, qualificationId));
            context.SaveChanges();

        }
    }
}
