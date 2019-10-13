using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;

namespace TEC_App.Services.CourseService
{
    public class CourseService : ICourseService
    {
        public readonly TecAppContext context;
        public CourseService(TecAppContext context)
        {
            this.context = context;
        }

        public List<Course> GetAllCourses()
        {
            return context.Set<Course>()
                .Include(c => c.PrerequisitesForCourse)
                .Include(c => c.QualificationsDevelopedByCourse)
                .Include(c => c.Sessions)
                .ThenInclude(c=>c.Session_Location_Pairs)
                .ThenInclude(c=>c.Location)
                .ToList();
        }

        public Course GetCourseFromId(int id)
        {
            return GetAllCourses().FirstOrDefault(d => d.Id == id);
        }

        public Course AddCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return course;
        }
    }
}
