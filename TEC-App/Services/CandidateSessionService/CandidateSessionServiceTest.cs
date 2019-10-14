using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.CandidateSessionService
{
    public class CandidateSessionServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public EmployeeService.CandidateService CandidateService { get; set; }
        public SessionService.SessionService SessionService { get; set; }
        public CandidateSessionService CandidateSessionService { get; set; }
        public Candidate Candidate { get; set; }
        public Session Session { get; set; }
        public Candidate_Session CandidateSession { get; set; }


        public CandidateSessionServiceTest()
        {
            TecAppContext = new TecAppContext();
            CandidateService = new EmployeeService.CandidateService(TecAppContext);
            SessionService = new SessionService.SessionService(TecAppContext);
            CandidateSessionService = new CandidateSessionService(TecAppContext);
        }

        [Test]
        public void AddTest()
        {
            var random = new Random();
            var candidates = CandidateService.GetAllCandidates();
            var sessions = SessionService.GetAllSessions();
            Candidate = CandidateService.GetAllCandidates()[random.Next(100)];
            Session = SessionService.GetAllSessions()[random.Next(100)];
            CandidateSession = CandidateSessionService.Add(new Candidate_Session()
            {
                Candidate = Candidate,
                Session = Session,
            });
        }

        [Test]
        public void GetTest()
        {
            var added = CandidateSessionService.GetFromIdPair(Candidate.Id, Session.Id);
            Assert.AreEqual(added.Id, CandidateSession.Id);
        }

        [Test]
        public void RemoveTest()
        {
            CandidateSessionService.Remove(Candidate.Id, Session.Id);
            var removed = CandidateSessionService.GetFromIdPair(Candidate.Id, Session.Id);
            Assert.AreEqual(removed.Id, -1);

        }
    }
}
