using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;
using TEC_App.Services.QualificationsService.QueryObjects;
using TEC_App.Views.AddCandidateView;

namespace TEC_App.Services.QualificationsService
{
    public interface IQualificationsService
    {
        List<Qualification> GetAllQualifications();
        List<AddCandidateQualificationsDTO> GetAllAndMapToAddCandidateQualificationDTOs();
        Qualification GetQualificationFromId(int id);
        Qualification AddQualification(Qualification qualification);
        void RemoveQualification(Qualification qualification);
    }
}
