using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;
using TEC_App.Views.AddCandidateView;
using TEC_App.Views.AddCourseView;
using TEC_App.Views.CandidateView;

namespace TEC_App.Services.QualificationsService.QueryObjects
{
    public static class QualificationWithCheckBoxDtoSelect
    {
        public static IQueryable<QualificationWithCheckboxViewDto> MapQualificationToQualificationWithCheckBoxDto(this IQueryable<Qualification> qualifications)
        {
            return qualifications.Select(qualification => new QualificationWithCheckboxViewDto()
            {
                Qualification = qualification
            });
        }
    }
}
