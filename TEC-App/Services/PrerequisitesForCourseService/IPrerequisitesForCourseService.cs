using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Services.PrerequisitesForCourseService
{
    public interface IPrerequisitesForCourseService
    {
        List<PrerequisitesForCourse> GetAll();
        PrerequisitesForCourse Add(PrerequisitesForCourse prerequisitesForCourse);
        PrerequisitesForCourse GetFromIdPair(int courseId, int qualificationId);
        void Remove(int courseId, int qualificationId);
    }
}
