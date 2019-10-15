using System;
using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Views.CandidateView;

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


        public List<Candidate> GetCandidatesQualifiedForRequiredQualification(int requiredQualificationId)
        {
            throw new NotImplementedException();
        }

        public List<Candidate> GetAllCandidates()
        {
            throw new NotImplementedException();
        }

        public List<CandidateViewDTO> GetAllCandidateViewDtos()
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

        public void AddAddressToCandidate(int candidateId, Address address)
        {
            throw new NotImplementedException();
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
