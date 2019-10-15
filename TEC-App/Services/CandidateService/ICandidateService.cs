using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Models.ViewDTO;
using TEC_App.Views.CandidateView;

namespace TEC_App.Services.EmployeeService
{
    public class AddCandidateDTO
    {

    }
    public interface ICandidateService
    {
        List<CandidateWithCheckBoxDTO> GetAllCandidatesAndMapToCandidateWithCheckBoxDTO();
        List<CandidateViewDTO> GetAllCandidateViewDtos();

        List<Candidate> GetCandidatesQualifiedForRequiredQualification(int requiredQualificationId);
        List<Candidate> GetAllCandidates();

        Candidate AddCandidate(Candidate candidate);
        void RemoveCandidate(Candidate candidate);
        Candidate GetCandidateFromId(int id);
        

    }
}
