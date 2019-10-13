using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
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
        public List<Job> GetAllJobs()
        {
            return context.Set<Job>().ToList();
        }

        public Job GetJobFromId(int id)
        {
            return GetAllJobs().FirstOrDefault(d => d.Id == id);
        }
    }
}
