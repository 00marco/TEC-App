using System;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Services.CourseService;
using TEC_App.Services.OpeningsService;

namespace TEC_App.Tests
{
	public class CourseManagement
	{
        //	Open a course
        //•	With prerequisites
        //•	With no prerequisites
        //	View all courses
        //	Remove course
        //	Let TEC specify training sessions for a course
        //	Update session details(number of attendees)
        public CourseManagement()
        {
            TecAppContext = new TecAppContext();
            CourseService = new CourseService(TecAppContext);
        }
        public ICourseService CourseService { get; set; }

        public TecAppContext TecAppContext { get; set; }

        [Test]
        public void GetCoursesTest()
        {
            var courses = CourseService.GetCourses();
            foreach (var v in courses)
            {
                Console.WriteLine();
                Console.WriteLine($"{v.Id}");
                Console.WriteLine($"{v.Name}");
                Console.WriteLine($"{v.PrerequisitesForCourse.Count}");
                Console.WriteLine($"{v.QualificationsDevelopedByCourse.Count}");
                Console.WriteLine($"{v.Sessions.Count}");
                Console.WriteLine();
            }
        }
    }
}