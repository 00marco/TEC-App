using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;

namespace TEC_App.Services.EmployeeService
{
    public class AddCandidateDTO
    {

    }
    public interface ICandidateService
    {
	    List<CandidateWithQualificationsDTO> GetCandidateList();
        AddCandidateDTO AddCandidate(AddCandidateDTO candidate);
    }
}
