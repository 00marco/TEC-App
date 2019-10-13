using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Models.ViewDTO;

namespace TEC_App.Services.EmployeeService
{
    public class AddCandidateDTO
    {

    }
    public interface ICandidateService
    {
        List<Candidate> GetCandidatesQualifiedForOpening(int openingId);
        List<Candidate> GetAllCandidates();
        List<CandidateViewDTO> GetAllCandidateViewDtos();
        Candidate AddCandidate(Candidate candidate);
        void RemoveCandidate(Candidate candidate);
        Candidate GetCandidateFromId(int id);
    }
}
