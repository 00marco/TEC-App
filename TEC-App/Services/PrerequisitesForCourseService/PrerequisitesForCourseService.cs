using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.PrerequisitesForCourseService
{
    public class PrerequisitesForCourseService : IPrerequisitesForCourseService
    {
        public readonly TecAppContext context;

        public PrerequisitesForCourseService(TecAppContext context)
        {
            this.context = context;
        }
        public List<PrerequisitesForCourse> GetAll()
        {
            return context.Set<PrerequisitesForCourse>()
                .Include(d => d.Qualification)
                .Include(d => d.Course)
                .ToList();

        }

        public PrerequisitesForCourse Add(PrerequisitesForCourse prerequisitesForCourse)
        {
            context.PrerequisitesForCourses.Add(prerequisitesForCourse);
            context.SaveChanges();
            return prerequisitesForCourse;
        }

        public PrerequisitesForCourse GetFromIdPair(int courseId, int qualificationId)
        {
            return GetAll().Single(d =>
                d.CourseId == courseId && d.QualificationId == qualificationId);

        }

        public void Remove(int courseId, int qualificationId)
        {
            context.Remove(GetFromIdPair(courseId, qualificationId));
            context.SaveChanges();
        }
    }
}
