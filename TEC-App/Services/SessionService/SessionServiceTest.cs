using System;
using System.Collections.Generic;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.SessionService
{
    public class SessionServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public Session Session { get; set; }
        public ISessionService SessionService { get; set; }

        public SessionServiceTest()
        {
            TecAppContext = new TecAppContext();
            SessionService = new SessionService(TecAppContext);
        }

        [Test]
        public void GetAllSessionsTest()
        {
            var sessions = SessionService.GetAllSessions();
            foreach (var v in sessions)
            {
                Console.WriteLine();
                Console.WriteLine($"{v.Candidate_Session_Pairs.Count}");
                Console.WriteLine($"{v.Course.Id}");
                Console.WriteLine($"{v.Id}");
                Console.WriteLine($"{v.Session_Location_Pairs.Count}");
                Console.WriteLine();
            }
        }

        [TestCase(1, 536)]
        [TestCase(2, 512)]
        [TestCase(3, 667)]
        [TestCase(4, 672)]
        public void GetSessionFromId(int id, int result)
        {
            var session = SessionService.GetSessionFromId(id);
            Assert.AreEqual(session.CourseId, result);
        }

        [Test]
        public void AddSessionTest()
        {
            var random = new Random();
            var newSession = new Session()
            {
                Candidate_Session_Pairs = new List<Candidate_Session>(),
                Course = new Course(),
                DateTimeEnd = DateTime.Now.AddDays(5),
                DateTimeStart = DateTime.Now,
                NumberOfAttendees = random.Next(),
                Session_Location_Pairs = new List<Session_Location>(),
                Price = random.Next(),

            };
            Session = SessionService.AddSession(newSession);
        }

        [Test]
        public void Y_TestAddedSession()
        {
            var addedSession = SessionService.GetSessionFromId(Session.Id);
            Assert.AreEqual(addedSession.NumberOfAttendees,Session.NumberOfAttendees);
        }

        [Test]
        public void Z_RemoveSessionTest()
        {
            SessionService.RemoveSession(Session);
            var removedSession = SessionService.GetSessionFromId(Session.Id);
            Assert.AreEqual(removedSession.Id, -1);
        }

    }
}
