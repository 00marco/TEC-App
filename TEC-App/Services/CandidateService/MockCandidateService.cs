﻿using System;
using System.Collections.Generic;
using TEC_App.Models.DTO;

namespace TEC_App.Services.EmployeeService
{
    public class MockCandidateService : ICandidateService
    {
	    public List<CandidateWithQualificationsDTO> GetCandidateList()
	    {
		    var candidateList = new List<CandidateWithQualificationsDTO>();
		    candidateList.Add(new CandidateWithQualificationsDTO()
		    {
			    CandidateName = "Marco",
			    Qualifications = "A,B"
		    });
		    candidateList.Add(new CandidateWithQualificationsDTO()
		    {
			    CandidateName = "Paolo",
			    Qualifications = "A,B"
		    });

		    return candidateList;

		}

        public AddCandidateDTO AddCandidate(AddCandidateDTO candidate)
        {
            return new AddCandidateDTO();
            
        }
    }
}