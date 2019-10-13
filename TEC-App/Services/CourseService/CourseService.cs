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
        public readonly TecAppContext _context;
        public CourseService(TecAppContext context)
        {
            _context = context;
        }

        public List<Course> GetCourses()
        {
            return _context.Set<Course>()
                .Include(c => c.PrerequisitesForCourse)
                .Include(c => c.QualificationsDevelopedByCourse)
                .Include(c => c.Sessions)
                .ThenInclude(c=>c.Session_Location_Pairs)
                .ThenInclude(c=>c.Location)
                .ToList();
        }

        public Course GetCourseFromId(int id)
        {
            return GetCourses().FirstOrDefault(d => d.Id == id);
        }
    }
}
