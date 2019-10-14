using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Services.QualificationDevelopedByCourseService
{
    public interface IQualificationDevelopedByCourseService
    {
        List<QualificationDevelopedByCourse> GetAll();
        QualificationDevelopedByCourse Add(QualificationDevelopedByCourse qualificationDevelopedByCourse);
        QualificationDevelopedByCourse GetFromIdPair(int courseId, int qualificationId);
        void Remove(int courseId, int qualificationId);
    }
}
