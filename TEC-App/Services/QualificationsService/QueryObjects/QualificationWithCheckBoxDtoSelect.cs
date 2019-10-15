using System.Linq;
using TEC_App.Models.Db;
using TEC_App.Models.ViewDTO;
using TEC_App.Views.AddCourseView;

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
