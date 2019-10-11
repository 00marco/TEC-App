using System;
using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;

namespace TEC_App.Services.EmployeeService
{
    public class MockCandidateService : ICandidateService
    {
	    public List<CandidateWithQualificationsDTO> GetCandidateWithQualificationsDtoList()
        {
            throw new NotImplementedException();
        }

        public List<Candidate> GetCandidateList()
        {
            throw new NotImplementedException();
        }

        public AddCandidateDTO AddCandidate(AddCandidateDTO candidate)
        {
            return new AddCandidateDTO();
            
        }

        public Candidate GetCandidateFromId(int id)
        {
            var candidate = new Candidate()
            {
                FirstName = "Marco",
                MiddleName = "Mahinay",
                LastName = "Pulido",
                Addresses = new List<Address_Candidate>(),
                CandidateQualifications = new List<Candidate_Qualification>(),
                Candidate_Session_Pairs = new List<Candidate_Session>(),
                JobHistories = new List<JobHistory>(),
                Placements = new List<Placement>(),
                Timestamp = DateTime.Now
            };
            return candidate;
        }
    }
}
