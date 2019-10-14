using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Services.JobHistoryCompanyService
{
    public interface IJobHistoryCompanyService
    {
        List<JobHistory_Company> GetAll();
        JobHistory_Company Add(JobHistory_Company jobHistoryCompany);
        JobHistory_Company GetFromIdPair(int jobHistoryId, int companyId);
        void Remove(int jobHistoryId, int companyId);
    }
}
