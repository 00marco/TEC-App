using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.QualificationsService
{
    public class QualificationsService : IQualificationsService
    {
        public readonly TecAppContext context;

        public QualificationsService(TecAppContext context)
        {
            this.context = context;
        }
        public List<Qualification> GetQualifications()
        {
            return context.Set<Qualification>()
                .ToList();
        }
    }
}
