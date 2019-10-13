using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Services.JobHistoryService
{
    public interface IJobHistoryService
    {
        List<JobHistory> GetAllJobHistories();
        JobHistory GetJobHistoryFromId(int id);
    }
}
