using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.CourseService
{
    public class CourseServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public Course Course { get; set; }
        public ICourseService CourseService { get; set; }

        public CourseServiceTest()
        {
            TecAppContext = new TecAppContext();
            CourseService = new CourseService(TecAppContext);
        }

        [Test]
        public void GetAllCoursesTest()
        {
            var courses = CourseService.GetAllCourses();
            foreach (var v in courses)
            {
                Console.WriteLine();
                Console.WriteLine($"Name\t\t\t{v.Name}");
                Console.WriteLine($"Prereq count\t\t{v.PrerequisitesForCourse.Count}");
                Console.WriteLine($"Qualificiations count\t{v.QualificationsDevelopedByCourse.Count}");
                Console.WriteLine($"Sessions count\t\t{v.Sessions.Count}");
                Console.WriteLine();
            }
        }

        //[TestCase(1, "TMN")]
        //[TestCase(2, "CWSP")]
        //[TestCase(3, "Disaster Recovery")]
        //[TestCase(4, "Nutrition")]
        public void GetCourseFromIdTest(int id, string result)
        {
            var course = CourseService.GetCourseFromId(id);
            Assert.AreEqual(course.Name, result);
        }

        [Test]
        public void AddCourseTest()
        {
            var random = new Random();
            var newCourse = new Course()
            {
                Name = $"Name-{random.Next()}",
                PrerequisitesForCourse = new List<PrerequisitesForCourse>(),
                QualificationsDevelopedByCourse = new List<QualificationDevelopedByCourse>(),
                Sessions = new List<Session>(),
            };
            Course = CourseService.AddCourse(newCourse);
        }

        [Test]
        public void Y_TestAddedCourse()
        {
            var addedCourse = CourseService.GetCourseFromId(Course.Id);
            Assert.AreEqual(Course.Name, addedCourse.Name);
        }

        [Test]
        public void Z_RemoveCourseTest()
        {
            CourseService.RemoveCourse(Course);
            var removedCourse = CourseService.GetCourseFromId(Course.Id);
            Assert.AreEqual(removedCourse.Id, -1);
        }
    }
}
