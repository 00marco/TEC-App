using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.JobHistoryService
{
    public class JobHistoryService : IJobHistoryService
    {
        public readonly TecAppContext context;

        public JobHistoryService(TecAppContext context)
        {
            this.context = context;
        }

        public List<JobHistory> GetAllJobHistories()
        {
            return context.Set<JobHistory>()
                .Include(d => d.JobHistory_Company_Pairs)
                .ThenInclude(d=>d.Company)
                .Include(d => d.JobHistory_Job_Pairs)
                .ThenInclude(d=>d.Job)
                .Include(d => d.Candidate)
                .ToList();
        }

        public JobHistory GetJobHistoryFromId(int id)
        {
            var jobHistory =  GetAllJobHistories().FirstOrDefault(d => d.Id == id);
            if (jobHistory == null)
            {
                return new JobHistory()
                {
                    Id = -1
                };
            }

            return jobHistory;
        }

        public JobHistory AddJobHistory(JobHistory jobHistory)
        {
            context.JobHistories.Add(jobHistory);
            context.SaveChanges();
            return jobHistory;
        }

        public void RemoveJobHistory(JobHistory jobHistory)
        {
            context.Remove(context.JobHistories.Single(d => d.Id == jobHistory.Id));
            context.SaveChanges();
        }
    }
}
