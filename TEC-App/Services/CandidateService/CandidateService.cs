using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;

namespace TEC_App.Services.EmployeeService
{
    public class CandidateService : ICandidateService
    {
	    private readonly TecAppContext context;

	    public CandidateService(TecAppContext context)
	    {
		    this.context = context;
	    }

        public List<Candidate> GetCandidatesQualifiedForOpening(Opening opening)
        {
            var candidates = GetAllCandidates();
            var candidatesQualifiedForOpening = new List<Candidate>();
            foreach (var v in candidates)
            {
                var candidateQualifications = v.CandidateQualifications.Where(d => d.CandidateId == v.Id);
                if (candidateQualifications.Any(a => a.QualificationId == opening.RequiredQualificationId))
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

        public Candidate AddCandidate(Candidate candidate)
        {
            context.Candidates.Add(candidate);
            context.SaveChanges();
            return candidate;
        }


        public Candidate GetCandidateFromId(int id)
        {
            var candidate = GetAllCandidates().FirstOrDefault(d => d.Id == id);
            return candidate;
        }
    }
}
