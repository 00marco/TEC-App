using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Services.JobHistoryService;
using TEC_App.Services.JobService;

namespace TEC_App.Services.JobHistoryJobService
{
    public class JobHistoryJobService : IJobHistoryJobService
    {
        public readonly TecAppContext context;

        public JobHistoryJobService(TecAppContext context)
        {
            this.context = context;
        }

        public List<JobHistory_Job> GetAll()
        {
            return context.Set<JobHistory_Job>()
                .Include(d => d.JobHistory)
                .Include(d => d.Job)
                .ToList();
        }

        public JobHistory_Job Add(JobHistory_Job jobHistoryJob)
        {
            context.JobHistory_Job_Pairs.Add(jobHistoryJob);
            context.SaveChanges();
            return jobHistoryJob;
        }

        public void Remove(int jobHistoryId, int jobId)
        {
            context.Remove(GetFromIdPair(jobHistoryId, jobId));
            context.SaveChanges();
        }

        public JobHistory_Job GetFromIdPair(int jobHistoryId, int jobId)
        {
            return GetAll().Single(d => d.JobHistoryId == jobHistoryId && d.JobId == jobId);

        }
    }
}
