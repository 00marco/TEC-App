﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Models.ViewDTO;
using TEC_App.Services.CandidateService.QueryObjects;
using TEC_App.Views.CandidateView;

namespace TEC_App.Services.EmployeeService
{
    public class CandidateService : ICandidateService
    {
	    private readonly TecAppContext context;

	    public CandidateService(TecAppContext context)
	    {
		    this.context = context;
	    }

        public List<Candidate> GetCandidatesQualifiedForRequiredQualification(int requiredQualificationId)
        {
            var candidates = GetAllCandidates();
            var candidatesQualifiedForOpening = new List<Candidate>();
            foreach (var v in candidates)
            {
                var candidateQualifications = v.CandidateQualifications.Where(d => d.CandidateId == v.Id);
                if (candidateQualifications.Any(a => a.QualificationId == requiredQualificationId))
                {
                    candidatesQualifiedForOpening.Add(v);
                }
            }

            return candidatesQualifiedForOpening;
        }

        public List<Candidate> GetAllCandidates()
        {
            return context.Set<Candidate>()
                .Include(d => d.Addresses)
                .ThenInclude(d => d.Address)
                .Include(d => d.Candidate_Session_Pairs)
                .ThenInclude(d => d.Session)
                .ThenInclude(d => d.Session_Location_Pairs)
                .ThenInclude(d => d.Location)
                //.ThenInclude(d=>d.Address_Location_Pairs)
                //.ThenInclude(d=>d.Address)
                .Include(d => d.CandidateQualifications)
                .ThenInclude(d => d.Qualification)
                .Include(d => d.JobHistories)
                .ThenInclude(d => d.JobHistory_Job_Pairs)
                .ThenInclude(d => d.Job)
                .Include(d => d.JobHistories)
                .ThenInclude(d => d.JobHistory_Company_Pairs)
                .ThenInclude(d => d.Company)
                .Include(d => d.Placements)
                .ThenInclude(d => d.Opening)
                .ThenInclude(d => d.Company)
                .ToList();
        }

        public List<CandidateWithCheckBoxDTO> GetAllCandidatesAndMapToCandidateWithCheckBoxDTO()
        {
            return context.Set<Candidate>()
                .Include(d => d.Addresses)
                .ThenInclude(d => d.Address)
                .Include(d => d.Candidate_Session_Pairs)
                .ThenInclude(d => d.Session)
                .ThenInclude(d => d.Session_Location_Pairs)
                .ThenInclude(d => d.Location)
                //.ThenInclude(d=>d.Address_Location_Pairs)
                //.ThenInclude(d=>d.Address)
                .Include(d => d.CandidateQualifications)
                .ThenInclude(d => d.Qualification)
                .Include(d => d.JobHistories)
                .ThenInclude(d => d.JobHistory_Job_Pairs)
                .ThenInclude(d => d.Job)
                .Include(d => d.JobHistories)
                .ThenInclude(d => d.JobHistory_Company_Pairs)
                .ThenInclude(d => d.Company)
                .Include(d => d.Placements)
                .ThenInclude(d => d.Opening)
                .ThenInclude(d => d.Company)
                .MapCandidateToCandidateWithCheckBoxDto()
                .ToList();
        }

        public List<CandidateViewDTO> GetAllCandidateViewDtos()
        {
            return context.Set<Candidate>()
                .Include(d => d.Addresses)
                .ThenInclude(d => d.Address)
                .Include(d => d.Candidate_Session_Pairs)
                .ThenInclude(d => d.Session)
                .ThenInclude(d => d.Session_Location_Pairs)
                .ThenInclude(d => d.Location)
                //.ThenInclude(d=>d.Address_Location_Pairs)
                //.ThenInclude(d=>d.Address)
                .Include(d => d.CandidateQualifications)
                .ThenInclude(d => d.Qualification)
                .Include(d => d.JobHistories)
                .ThenInclude(d => d.JobHistory_Job_Pairs)
                .ThenInclude(d => d.Job)
                .Include(d => d.JobHistories)
                .ThenInclude(d => d.JobHistory_Company_Pairs)
                .ThenInclude(d => d.Company)
                .Include(d => d.Placements)
                .ThenInclude(d => d.Opening)
                .ThenInclude(d => d.Company)
                .MapCandidateToDto()
                .ToList();
        }

        public Candidate AddCandidate(Candidate candidate)
        {
            context.Candidates.Add(candidate);
            context.SaveChanges();
            return candidate;
        }

        public Candidate UpdateCandidate(Candidate oldCandidate, Candidate newCandidate)
        {
            var candidate = context.Candidates.Find(oldCandidate.Id);
            candidate.FirstName = newCandidate.FirstName;
            candidate.MiddleName = newCandidate.MiddleName;
            candidate.LastName = newCandidate.LastName;
            candidate.Timestamp = DateTime.Now;
            context.SaveChanges();
            return candidate;
        }

        public void RemoveCandidate(Candidate candidate)
        {
            context.Remove(context.Candidates.Single(d => d.Id == candidate.Id));
            context.SaveChanges();
        }


        public Candidate GetCandidateFromId(int id)
        {
            var candidate = GetAllCandidates().FirstOrDefault(d => d.Id == id);
            if (candidate == null)
            {
                return new Candidate()
                {
                    Id = -1
                };
            }
            return candidate;
        }

        
    }
}
