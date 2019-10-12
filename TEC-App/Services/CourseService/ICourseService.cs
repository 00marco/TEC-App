using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;

namespace TEC_App.Services.CourseService
{
    public interface ICourseService
    {
        List<Course> GetCourses();
        List<CourseWithLocationDTO> GetCourseViewDtoList();

    }
}
