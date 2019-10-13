using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.SessionService
{
    public class SessionService : ISessionService
    {
        public readonly TecAppContext context;

        public SessionService(TecAppContext context)
        {
            this.context = context;
        }
        public List<Session> GetAllSessions()
        {
            return context.Set<Session>()
                .Include(d => d.Candidate_Session_Pairs)
                .Include(d => d.Course)
                .Include(d => d.Session_Location_Pairs)
                .ToList();
        }

        public Session GetSessionFromId(int id)
        {
            return GetAllSessions().FirstOrDefault(d => d.Id == id);
        }
    }
}
