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
        List<Candidate> GetCandidatesQualifiedForOpening(Opening opening);
        List<Candidate> GetAllCandidates();
        Candidate AddCandidate(Candidate candidate);
        Candidate GetCandidateFromId(int id);
    }
}
