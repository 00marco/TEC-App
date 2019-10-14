using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Models.ViewDTO;
using TEC_App.Services.CandidateService.QueryObjects;

namespace TEC_App.Services.EmployeeService
{
    public class CandidateService : ICandidateService
    {
	    private readonly TecAppContext context;

	    public CandidateService(TecAppContext context)
	    {
		    this.context = context;
	    }

        public List<Candidate> GetCandidatesQualifiedForOpening(int openingId)
        {
            var candidates = GetAllCandidates();
            var candidatesQualifiedForOpening = new List<Candidate>();
            foreach (var v in candidates)
            {
                var candidateQualifications = v.CandidateQualifications.Where(d => d.CandidateId == v.Id);
                if (candidateQualifications.Any(a => a.QualificationId == openingId))
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

        public void AddAddressToCandidate(int candidateId, Address address)
        {
        }

        public void AddSessionToCandidate(int candidateId, Candidate candidate)
        {
            throw new NotImplementedException();
        }

        public void AddQualificationToCandidate(int candidateId, Qualification qualification)
        {
            throw new NotImplementedException();
        }

        public void AddJobHistoryToCandidate(int candidateId, JobHistory jobHistory)
        {
            throw new NotImplementedException();
        }
    }
}
