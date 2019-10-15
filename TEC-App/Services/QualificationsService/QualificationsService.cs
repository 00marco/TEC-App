using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Services.QualificationsService.QueryObjects;
using TEC_App.Views.AddCandidateView;
using TEC_App.Views.AddCourseView;

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

        public List<QualificationWithCheckboxViewDto> GetAllAndMapToQualificationWithCheckBoxDto()
        {
            return context.Set<Qualification>()
                .Include(d => d.CandidatesQualifications)
                .Include(d => d.Courses)
                .Include(d => d.Openings)
                .Include(d => d.PrerequisitesForCourse)
                .MapQualificationToQualificationWithCheckBoxDto()
                .ToList();

        }

        public Qualification GetQualificationFromId(int id)
        {
            var qualification = GetAllQualifications().FirstOrDefault(d => d.Id == id);
            if (qualification == null)
            {
                return new Qualification()
                {
                    Id = -1
                };
            }

            return qualification;
        }

        public Qualification AddQualification(Qualification qualification)
        {
            context.Qualifications.Add(qualification);
            context.SaveChanges();
            return qualification;
        }

        public void RemoveQualification(Qualification qualification)
        {
            context.Remove(context.Qualifications.Single(d => d.Id == qualification.Id));
            context.SaveChanges();
        }
    }
}
