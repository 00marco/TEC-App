using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.CandidateSessionService
{
    public class CandidateSessionService : ICandidateSessionService
    {
        public readonly TecAppContext context;

        public CandidateSessionService(TecAppContext context)
        {
            this.context = context;
        }
        public List<Candidate_Session> GetAll()
        {
            return context.Set<Candidate_Session>()
                .Include(d => d.Candidate)
                .Include(d => d.Session)
                .ToList();
        }

        public Candidate_Session GetFromIdPair(int candidateId, int sessionId)
        {
            return GetAll().Single(d => d.CandidateId == candidateId && d.SessionId == sessionId);
        }

        public void Remove(int candidateId, int sessionId)
        {
            context.Remove(GetFromIdPair(candidateId, sessionId));
            context.SaveChanges();
        }

        public Candidate_Session Add(Candidate_Session candidateSession)
        {
            context.Candidate_Session_Pairs.Add(candidateSession);
            context.SaveChanges();
            return candidateSession;
        }
    }
}
