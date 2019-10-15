using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Views.AddCourseView
{
    public class QualificationWithCheckboxViewDto
    {
        public Qualification Qualification { get; set; }
        public bool IsSelected { get; set; }
    }
}
