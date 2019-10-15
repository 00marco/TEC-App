using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;
using TEC_App.Views.AddCandidateView;

namespace TEC_App.Services.QualificationsService.QueryObjects
{
    public static class AddCandidateQualificationDtoSelect
    {
        public static IQueryable<AddCandidateQualificationsDTO> MapQualificationToAddCandidateDTO(this IQueryable<Qualification> qualifications)
        {
            return qualifications.Select(qualification => new AddCandidateQualificationsDTO()
            {
                Qualification = qualification
            });
        }
    }
}
