using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;

namespace TEC_App.Services.CourseService
{
    public class MockCourseService : ICourseService
    {
        public List<Course> GetAllCourses()
        {
            throw new System.NotImplementedException();
        }

        public Course GetCourseFromId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Course AddCourse(Course course)
        {
            throw new System.NotImplementedException();
        }

        public List<CourseWithLocationDTO> GetCourseViewDtoList()
        {
            throw new System.NotImplementedException();
        }
    }
}
