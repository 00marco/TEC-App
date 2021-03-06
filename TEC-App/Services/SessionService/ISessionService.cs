﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;
using TEC_App.Views.SessionsView;

namespace TEC_App.Services.SessionService
{
    public interface ISessionService
    {
        List<Session> GetAllSessions();
        List<Session> GetAllSessionsOfGivenCourse(int courseId);

        List<SessionViewDTO> GetAllSessionsAndMapToViewDTO();
        List<SessionViewDTO> GetAllSessionsOfGivenCourseAndMapToViewDTO(int courseId);
        Session GetSessionFromId(int id);
        Session AddSession(Session session);
        Session UpdateSessionNumberOfAttendees(Session oldSession, int numberOfAttendees);
        void RemoveSession(Session session);
    }
}
