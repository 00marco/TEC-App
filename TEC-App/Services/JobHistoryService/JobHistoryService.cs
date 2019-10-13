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
                .Include(d => d.JobHistory_Job_Pairs)
                .Include(d => d.Candidate)
                .ToList();
        }

        public JobHistory GetJobHistoryFromId(int id)
        {
            return GetAllJobHistories().FirstOrDefault(d => d.Id == id);
        }
    }
}
