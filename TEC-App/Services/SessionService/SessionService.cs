using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Services.SessionService.QueryObjects;
using TEC_App.Views.SessionsView;

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
                .ThenInclude(d=>d.Location)
                .ThenInclude(d=>d.Address)
                .ToList();
        }

        public List<Session> GetAllSessionsOfGivenCourse(int courseId)
        {
            return GetAllSessions().Where(d => d.CourseId == courseId).ToList();
        }

        public List<SessionViewDTO> GetAllSessionsAndMapToViewDTO()
        {
            return context.Set<Session>()
                .Include(d => d.Candidate_Session_Pairs)
                .Include(d => d.Course)
                .Include(d => d.Session_Location_Pairs)
                .ThenInclude(d => d.Location)
                .ThenInclude(d => d.Address)
                .MapToSessionViewDTO()
                .ToList();
        }

        public List<SessionViewDTO> GetAllSessionsOfGivenCourseAngMapToViewDTO(int courseId)
        {
            return GetAllSessionsAndMapToViewDTO().Where(d => d.Session.CourseId == courseId).ToList();

        }

        public Session GetSessionFromId(int id)
        {
            var session = GetAllSessions().FirstOrDefault(d => d.Id == id);
            if (session == null)
            {
                return new Session()
                {
                    Id = -1
                };
            }

            return session;
        }

        public Session AddSession(Session session)
        {
            context.Sessions.Add(session);
            context.SaveChanges();
            return session;
        }

        public void RemoveSession(Session session)
        {
            context.Remove(context.Sessions.Single(d => d.Id == session.Id));
            context.SaveChanges();
        }
    }
}
