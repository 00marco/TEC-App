using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.QualificationDevelopedByCourseService
{
    public class QualificationDevelopedByCourseService : IQualificationDevelopedByCourseService
    {
        public readonly TecAppContext context;

        public QualificationDevelopedByCourseService(TecAppContext context)
        {
            this.context = context;
        }
        public List<QualificationDevelopedByCourse> GetAll()
        {
            return context.Set<QualificationDevelopedByCourse>()
                .Include(d => d.Course)
                .Include(d => d.Qualification)
                .ToList();
        }

        public QualificationDevelopedByCourse Add(QualificationDevelopedByCourse qualificationDevelopedByCourse)
        {
            context.QualificationsDevelopedByCourse.Add(qualificationDevelopedByCourse);
            context.SaveChanges();
            return qualificationDevelopedByCourse;
        }

        public QualificationDevelopedByCourse GetFromIdPair(int courseId, int qualificationId)
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
