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
            var job = GetAllJobs().FirstOrDefault(d => d.Id == id);
            if (job == null)
            {
                return new Job(){Id = -1};
            }

            return job;
        }

        public void RemoveJob(Job job)
        {
            context.Remove(context.Jobs.Single(d => d.Id == job.Id));
            context.SaveChanges();
        }

        public Job AddJob(Job job)
        {
            context.Jobs.Add(job);
            context.SaveChanges();
            return job;
        }
    }
}
