using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Services.SessionService
{
    public interface ISessionService
    {
        List<Session> GetAllSessions();
        Session GetSessionFromId(int id);
        Session AddSession(Session session);
        void RemoveSession(Session session);
    }
}
