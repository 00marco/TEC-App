using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Services.JobService
{
    public interface IJobService
    {
        List<Job> GetAllJobs();
        Job GetJobFromId(int id);
        void RemoveJob(Job job);
        Job AddJob(Job job);
    }
}
