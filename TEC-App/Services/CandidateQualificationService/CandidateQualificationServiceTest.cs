using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Services.EmployeeService;
using TEC_App.Services.QualificationsService;

namespace TEC_App.Services.CandidateQualificationService
{
    public class CandidateQualificationServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public ICandidateQualificationService CandidateQualificationService { get; set; }
        public ICandidateService CandidateService { get; set; }
        public IQualificationsService QualificationsService { get; set; }
        public Candidate_Qualification CandidateQualification { get; set; }
        public Candidate Candidate { get; set; }
        public Qualification Qualification { get; set; }

        public CandidateQualificationServiceTest()
        {
            TecAppContext = new TecAppContext();
            CandidateQualificationService = new CandidateQualificationService(TecAppContext);
            CandidateService = new EmployeeService.CandidateService(TecAppContext);
            QualificationsService = new QualificationsService.QualificationsService(TecAppContext);
        }

        [Test]
        public void AddTest()
        {
            var random = new Random();
            Candidate = CandidateService.GetAllCandidates()[random.Next(100)];
            Qualification = QualificationsService.GetAllQualifications()[random.Next(10)];
            CandidateQualification = CandidateQualificationService.Add(new Candidate_Qualification()
            {
                Candidate = Candidate,
                CandidateId = Candidate.Id,
                Qualification = Qualification,
                QualificationId = Qualification.Id
            });

        }

        [Test]
        public void GetTest()
        {
            var added = CandidateQualificationService.GetFromIdPair(CandidateQualification.CandidateId,
                CandidateQualification.QualificationId);
            Assert.AreEqual(added.CandidateId, Candidate.Id);
            Assert.AreEqual(added.QualificationId, Qualification.Id);
            Assert.AreEqual(added.Id, CandidateQualification.Id);
        }

        [Test]
        public void RemoveTest()
        {
            CandidateQualificationService.Remove(Candidate.Id, Qualification.Id);
            var removed = CandidateQualificationService.GetFromIdPair(Candidate.Id, Qualification.Id);
            Assert.AreEqual(removed.Id, -1);
        }
    }
}
