using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.QualificationsService
{
    public class QualificationServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public IQualificationsService QualificationsService { get; set; }
        public Qualification Qualification { get; set; }

        public QualificationServiceTest()
        {
            TecAppContext = new TecAppContext();
            QualificationsService = new QualificationsService(TecAppContext);
        }

        [Test]
        public void GetAllQualificationsTest()
        {
            var qualifications = QualificationsService.GetAllQualifications();
            foreach (var v in qualifications)
            {
                Console.WriteLine();
                Console.WriteLine($"{v.Code}");
                Console.WriteLine($"{v.Description}");
                Console.WriteLine($"{v.QualificationsDevelopedByCourse}");
                Console.WriteLine($"{v.CandidatesQualifications.Count}");
                Console.WriteLine($"{v.Openings.Count}");
                Console.WriteLine($"{v.PrerequisitesForCourse.Count}");
                Console.WriteLine();
            }
        }

        //[TestCase(1, "SEC-45")]
        //[TestCase(2, "SEC-60")]
        //[TestCase(3, "CLERK")]
        //[TestCase(4, "PRG-VB")]
        public void GetQualificationFromIdTest(int id, string result)
        {
            var qualification = QualificationsService.GetQualificationFromId(id);
            Assert.AreEqual(qualification.Code, result);
        }

        [Test]
        public void AddQualificationTest()
        {
            var random = new Random();
            var newQualification = new Qualification()
            {
                CandidatesQualifications = new List<Candidate_Qualification>(),
                Code = $"Code-{random.Next()}",
                Description = $"Description-{random.Next()}",
                Openings = new List<Opening>(),
                PrerequisitesForCourse = new List<PrerequisitesForCourse>(),
                QualificationsDevelopedByCourse = new List<QualificationDevelopedByCourse>()
            };
            Qualification = QualificationsService.AddQualification(newQualification);
        }

        [Test]
        public void Y_TestAddedQualification()
        {
            var addedQualification = QualificationsService.GetQualificationFromId(Qualification.Id);
            Assert.AreEqual(addedQualification.Id, Qualification.Id);

        }

        [Test]
        public void Z_RemoveQualificationTest()
        {
            QualificationsService.RemoveQualification(Qualification);
            var removedQualification = QualificationsService.GetQualificationFromId(Qualification.Id);
            Assert.AreEqual(removedQualification.Id, -1);
        }
    }


}
