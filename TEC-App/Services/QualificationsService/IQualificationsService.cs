using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;
using TEC_App.Models.ViewDTO;
using TEC_App.Views.AddCandidateView;
using TEC_App.Views.AddCourseView;

namespace TEC_App.Services.QualificationsService
{
    public interface IQualificationsService
    {
        List<Qualification> GetAllQualifications();
        List<QualificationWithCheckboxViewDto> GetAllAndMapToQualificationWithCheckBoxDto();
        Qualification GetQualificationFromId(int id);
        Qualification AddQualification(Qualification qualification);
        void RemoveQualification(Qualification qualification);
    }
}
