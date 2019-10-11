using System.Collections.Generic;
using TEC_App.Models.Db;

namespace TEC_App.Services.CourseService
{
    public interface ICourseService
    {
        List<Course> GetCourses();
    }
}
