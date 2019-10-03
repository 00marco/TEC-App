using System.Collections.Generic;
using TEC_App.Models.DTO;

namespace TEC_App.Services.EmployeeService
{
    public interface IEmployeeService
    {
	    List<CandidateWithQualificationsDTO> GetCandidateList();
    }
}
