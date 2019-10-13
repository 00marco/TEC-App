using System;
using NUnit.Framework;
using TEC_App.Helpers;

namespace TEC_App.Services.SessionService
{
    public class SessionServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
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

    }
}
