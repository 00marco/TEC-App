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
            var testList = new List<CandidateWithQualificationsDTO>();
            for (int x = 0; x < 3; x++)
            {
                testList.Add(new CandidateWithQualificationsDTO()
                {
                    ActualCandidateId = x,
                    CandidateName = $"Student-{x}",
                    Qualifications = $"{x},{x+1},{x+2}"
                });
            }

            return testList;
        }

        public List<Candidate> GetCandidatesQualifiedForOpening(Opening opening)
        {
            throw new NotImplementedException();
        }

        public List<Candidate> GetAllCandidates()
        {
            throw new NotImplementedException();
        }

        public Candidate AddCandidate(Candidate candidate)
        {
            throw new NotImplementedException();
        }

        public void RemoveCandidate(Candidate candidate)
        {
            throw new NotImplementedException();
        }

        public void AddCandidate(AddCandidateDTO candidate)
        {
            throw new NotImplementedException();
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
