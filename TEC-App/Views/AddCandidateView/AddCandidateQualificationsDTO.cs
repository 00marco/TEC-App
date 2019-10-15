using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Views.AddCandidateView
{
    public class AddCandidateQualificationsDTO
    {
        public Qualification Qualification { get; set; }
        public bool IsSelected { get; set; }

    }
}
