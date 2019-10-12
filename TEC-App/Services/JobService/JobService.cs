using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.JobService
{
    public class JobService : IJobService
    {
        public readonly TecAppContext context;

        public JobService(TecAppContext context)
        {
            this.context = context;
        }
        public List<Job> GetJobs()
        {
            return context.Set<Job>().ToList();
        }
    }
}
