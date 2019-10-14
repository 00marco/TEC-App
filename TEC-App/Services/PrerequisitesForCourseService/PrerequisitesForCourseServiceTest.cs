using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.PrerequisitesForCourseService
{
    public class PrerequisitesForCourseServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public PrerequisitesForCourseService PrerequisitesForCourseService { get; set; }
        public QualificationsService.QualificationsService QualificationsService { get; set; }
        public CourseService.CourseService CourseService { get; set; }
        public Qualification Qualification { get; set; }
        public Course Course { get; set; }
        public PrerequisitesForCourse PrerequisitesForCourse { get; set; }

        public PrerequisitesForCourseServiceTest()
        {
            TecAppContext = new TecAppContext();
            PrerequisitesForCourseService = new PrerequisitesForCourseService(TecAppContext);
            QualificationsService = new QualificationsService.QualificationsService(TecAppContext);
            CourseService = new CourseService.CourseService(TecAppContext);
        }

        

        [Test]
        public void AddTest()
        {
            var random = new Random();
            Qualification = QualificationsService.GetAllQualifications()[random.Next(10)];
            Course = CourseService.GetAllCourses()[random.Next(100)];
            PrerequisitesForCourse = PrerequisitesForCourseService.Add(new PrerequisitesForCourse()
            {
                Qualification = Qualification,
                QualificationId = Qualification.Id,
                Course = Course,
                CourseId = Course.Id
            });

        }

        [Test]
        public void GetTest()
        {
            var added = PrerequisitesForCourseService.GetFromIdPair(Course.Id, Qualification.Id);
            Assert.AreEqual(added.Id,PrerequisitesForCourse.Id);
        }

        [Test]
        public void RemoveTest()
        {
            PrerequisitesForCourseService.Remove(Course.Id, Qualification.Id);
            var removed = PrerequisitesForCourseService.GetFromIdPair(Course.Id, Qualification.Id);
            Assert.AreEqual(removed.Id, -1);

        }

    }
}
