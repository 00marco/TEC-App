using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Views.AddCourseView;
using TEC_App.Views.CourseView;

namespace TEC_App.Services.CourseService
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();
        List<CourseViewDTO> GetCourseViewDtos();

        Course GetCourseFromId(int id);
        Course AddCourse(Course course);
        void RemoveCourse(Course course);
    }
}
