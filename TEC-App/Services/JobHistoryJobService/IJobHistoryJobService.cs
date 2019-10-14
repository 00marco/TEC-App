using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Services.JobHistoryJobService
{
    public interface IJobHistoryJobService
    {
        List<JobHistory_Job> GetAll();
        JobHistory_Job Add(JobHistory_Job jobHistoryJob);
        void Remove(int jobHistoryId, int jobId);
        JobHistory_Job GetFromIdPair(int jobHistoryId, int jobId);

        
    }
}
