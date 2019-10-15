using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;
using TEC_App.Views.SessionsView;

namespace TEC_App.Services.SessionService.QueryObjects
{
    public static class SessionViewDtoSelect
    {
        public static IQueryable<SessionViewDTO> MapToSessionViewDTO(this IQueryable<Session> sessions)
        {
            return sessions.Select(session => new SessionViewDTO()
            {
                Session = session
            });
        }
    }
}
