using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.SessionLocationService
{
    public class SessionLocationService : ISessionLocationService
    {
        public readonly TecAppContext context;

        public SessionLocationService(TecAppContext context)
        {
            this.context = context;
        }
        public List<Session_Location> GetAll()
        {
            return context.Set<Session_Location>()
                .Include(d => d.Session)
                .Include(d => d.Location)
                .ToList();
        }

        public Session_Location GetFromIdPair(int sessionId, int locationId)
        {
            var ret = GetAll().FirstOrDefault(d => d.LocationId == locationId && d.SessionId == sessionId);
            if (ret == null)
            {
                return new Session_Location()
                {
                    Id = -1
                };
            }

            return ret;
        }

        public void Remove(int sessionId, int locationId)
        {
            context.Remove(GetFromIdPair(sessionId, locationId));
            context.SaveChanges();
        }

        public Session_Location Add(Session_Location sessionLocation)
        {
            context.Session_Location_Pairs.Add(sessionLocation);
            context.SaveChanges();
            return sessionLocation;
        }
    }
}
