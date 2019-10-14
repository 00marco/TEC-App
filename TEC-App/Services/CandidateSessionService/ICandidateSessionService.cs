using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Services.CandidateSessionService
{
    public interface ICandidateSessionService
    {
        List<Candidate_Session> GetAll();
        Candidate_Session GetFromIdPair(int candidateId, int sessionId);
        void Remove(int candidateId, int sessionId);
        Candidate_Session Add(Candidate_Session candidateSession);
    }
}
