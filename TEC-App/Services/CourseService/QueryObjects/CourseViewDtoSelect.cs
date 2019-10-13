using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;
using TEC_App.Models.ViewDTO;

namespace TEC_App.Services.CourseService.QueryObjects
{
    public static class CourseViewDtoSelect
    {
        public static IQueryable<CourseViewDTO> MapCourseToDto(this IQueryable<Course> courses)
        {
            return courses.Select(course => new CourseViewDTO()
            {
                Course = course
            });
        }
    }
}
