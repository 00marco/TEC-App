using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.QualificationsService
{
    public class QualificationsService : IQualificationsService
    {
        public readonly TecAppContext context;

        public QualificationsService(TecAppContext context)
        {
            this.context = context;
        }
        public List<Qualification> GetAllQualifications()
        {
            return context.Set<Qualification>()
                .Include(d=>d.CandidatesQualifications)
                .Include(d=>d.Courses)
                .Include(d=>d.Openings)
                .Include(d=>d.PrerequisitesForCourse)
                .ToList();
        }

        public Qualification GetQualificationFromId(int id)
        {
            return GetAllQualifications().FirstOrDefault(d => d.Id == id);
        }

        public Qualification AddQualification(Qualification qualification)
        {
            context.Qualifications.Add(qualification);
            context.SaveChanges();
            return qualification;
        }
    }
}
