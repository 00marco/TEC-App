using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.QualificationDevelopedByCourseService
{
    public class QualificationsDevelopedByCourseServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public QualificationDevelopedByCourseService QualificationDevelopedByCourseService { get; set; }
        public QualificationsService.QualificationsService QualificationsService { get; set; }
        public CourseService.CourseService CourseService { get; set; }
        public Qualification Qualification { get; set; }
        public Course Course { get; set; }
        public QualificationDevelopedByCourse QualificationDevelopedByCourse { get; set; }

        public QualificationsDevelopedByCourseServiceTest()
        {
            TecAppContext = new TecAppContext();
            QualificationDevelopedByCourseService = new QualificationDevelopedByCourseService(TecAppContext);
            QualificationsService = new QualificationsService.QualificationsService(TecAppContext);
            CourseService = new CourseService.CourseService(TecAppContext);

        }

        [Test]
        public void AddTest()
        {
            var random = new Random();
            Qualification = QualificationsService.GetAllQualifications()[random.Next(10)];
            Course = CourseService.GetAllCourses()[random.Next(100)];
            QualificationDevelopedByCourse = QualificationDevelopedByCourseService.Add(
                new QualificationDevelopedByCourse()
                {
                    Course = Course,
                    CourseId = Course.Id,
                    Qualification = Qualification,
                    QualificationId = Qualification.Id
                });
            
        }

        [Test]
        public void GetTest()
        {
            var added = QualificationDevelopedByCourseService.GetFromIdPair(Course.Id, Qualification.Id);
            Assert.AreEqual(added.Id, QualificationDevelopedByCourse.Id);
        }

        [Test]
        public void RemoveTest()
        {
            QualificationDevelopedByCourseService.Remove(Course.Id, Qualification.Id);
            var removed = QualificationDevelopedByCourseService.GetFromIdPair(Course.Id, Qualification.Id);
            Assert.AreEqual(removed.Id, -1);

        }
    }
}
