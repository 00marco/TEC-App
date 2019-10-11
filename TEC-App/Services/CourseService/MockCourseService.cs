using System.Collections.Generic;
using TEC_App.Models.Db;

namespace TEC_App.Services.CourseService
{
    public class MockCourseService : ICourseService
    {
        public List<Course> GetCourses()
        {
            throw new System.NotImplementedException();
        }
    }
}
