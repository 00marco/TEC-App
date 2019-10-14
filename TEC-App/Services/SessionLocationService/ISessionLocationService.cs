using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Services.SessionLocationService
{
    public interface ISessionLocationService
    {
        List<Session_Location> GetAll();
        Session_Location GetFromIdPair(int sessionId, int locationId);
        void Remove(int sessionId, int locationId);
        Session_Location Add(Session_Location sessionLocation);
    }
}
