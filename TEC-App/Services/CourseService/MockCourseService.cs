using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Models.ViewDTO;
using TEC_App.Views.AddCourseView;
using TEC_App.Views.CourseView;

namespace TEC_App.Services.CourseService
{
    public class MockCourseService : ICourseService
    {
        public List<Course> GetAllCourses()
        {
            throw new System.NotImplementedException();
        }

        public List<CourseViewDTO> GetCourseViewDtos()
        {
            throw new System.NotImplementedException();
        }

        public List<QualificationWithCheckboxViewDto> GetAllAndMapToQualificationWithCheckBoxViewDtos()
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

        public void RemoveCourse(Course course)
        {
            throw new System.NotImplementedException();
        }

        public List<CourseWithLocationDTO> GetCourseViewDtoList()
        {
            throw new System.NotImplementedException();
        }
    }
}
