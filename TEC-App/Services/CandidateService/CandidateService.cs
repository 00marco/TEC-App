using System;
using System.Collections.Generic;
using System.Linq;
using TEC_App.Helpers;
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

	    public List<CandidateWithQualificationsDTO> GetCandidateList()
	    {
		    throw new NotImplementedException();
	    }

        public AddCandidateDTO AddCandidate(AddCandidateDTO candidate)
        {
            throw new NotImplementedException();
        }
    }
}
