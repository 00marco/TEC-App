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
	    private readonly TecAppContext _context;

	    public CandidateService(TecAppContext context)
	    {
		    _context = context;
	    }

	    public List<CandidateWithQualificationsDTO> GetCandidateWithQualificationsDtoList()
        {
            var list = GetCandidateList();
            var dtoList = new List<CandidateWithQualificationsDTO>();
            foreach (var v in list)
            {
                dtoList.Add(new CandidateWithQualificationsDTO()
                {
                    ActualCandidateId = v.Id,
                    CandidateName = v.FullName,
                    Qualifications =  string.Join(", ", v.CandidateQualifications)
                });
            }

            return dtoList;
        }

        public List<Candidate> GetCandidateList()
        {
            return _context.Set<Candidate>()
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

        public AddCandidateDTO AddCandidate(AddCandidateDTO candidate)
        {
            throw new NotImplementedException();
        }

        public Candidate GetCandidateFromId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
