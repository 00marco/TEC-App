using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Models.ViewDTO;
using TEC_App.Services.CourseService.QueryObjects;

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

        public List<CourseViewDTO> GetCourseViewDtos()
        {
            return context.Set<Course>()
                .Include(c => c.PrerequisitesForCourse)
                .Include(c => c.QualificationsDevelopedByCourse)
                .Include(c => c.Sessions)
                .ThenInclude(c => c.Session_Location_Pairs)
                .ThenInclude(c => c.Location)
                .MapCourseToDto()
                .ToList();
        }


        public Course GetCourseFromId(int id)
        {
            var course = GetAllCourses().FirstOrDefault(d => d.Id == id);
            if (course == null)
            {
                return new Course()
                {
                    Id = -1
                };
            }

            return course;
        }

        public Course AddCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return course;
        }

        public void RemoveCourse(Course course)
        {
            context.Remove(context.Courses.Single(d => d.Id == course.Id));
            context.SaveChanges();
        }
    }
}
