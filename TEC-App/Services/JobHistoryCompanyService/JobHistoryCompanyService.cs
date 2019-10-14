using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.JobHistoryCompanyService
{
    public class JobHistoryCompanyService : IJobHistoryCompanyService
    {
        public readonly TecAppContext context;

        public JobHistoryCompanyService(TecAppContext context)
        {
            this.context = context;
        }

        public List<JobHistory_Company> GetAll()
        {
            return context.Set<JobHistory_Company>()
                .Include(d => d.JobHistory)
                .Include(d => d.Company)
                .ToList();
        }

        public JobHistory_Company Add(JobHistory_Company jobHistoryCompany)
        {
            context.JobHistory_Company_Pairs.Add(jobHistoryCompany);
            context.SaveChanges();
            return jobHistoryCompany;
        }

        public JobHistory_Company GetFromIdPair(int jobHistoryId, int companyId)
        {
            var ret= GetAll().FirstOrDefault(d => d.JobHistoryId == jobHistoryId && d.CompanyId == companyId);
            if (ret == null)
            {
                return new JobHistory_Company()
                {
                    Id = -1
                };
            }

            return ret;

        }

        public void Remove(int jobHistoryId, int companyId)
        {
            context.Remove(GetFromIdPair(jobHistoryId, companyId));
            context.SaveChanges();
        }
    }
}
