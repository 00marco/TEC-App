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
	    List<CandidateWithQualificationsDTO> GetCandidateWithQualificationsDtoList();
        List<Candidate> GetCandidateList();
        void AddCandidate(AddCandidateDTO candidate);
        Candidate GetCandidateFromId(int id);
    }
}
