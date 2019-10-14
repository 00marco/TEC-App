using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.JobHistoryCompanyService
{
    public class JobHistoryCompanyServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public JobHistoryService.JobHistoryService JobHistoryService { get; set; }
        public CompanyService.CompanyService CompanyService { get; set; }
        public JobHistoryCompanyService JobHistoryCompanyService { get; set; }
        public JobHistory JobHistory { get; set; }
        public Company Company { get; set; }
        public JobHistory_Company JobHistoryCompany { get; set; }


        public JobHistoryCompanyServiceTest()
        {
            TecAppContext = new TecAppContext();
            JobHistoryService = new JobHistoryService.JobHistoryService(TecAppContext);
            CompanyService = new CompanyService.CompanyService(TecAppContext);
            JobHistoryCompanyService = new JobHistoryCompanyService(TecAppContext);
        }

        [Test]
        public void AddTest()
        {
            var random = new Random();
            JobHistory = JobHistoryService.GetAllJobHistories()[random.Next(100)];
            Company = CompanyService.GetAllCompanies()[random.Next(100)];
            JobHistoryCompany = JobHistoryCompanyService.Add(new JobHistory_Company()
            {
                JobHistory = JobHistory,
                JobHistoryId = JobHistory.Id,
                Company = Company,
                CompanyId = Company.Id
            });
        }

        [Test]
        public void GetTest()
        {
            var added = JobHistoryCompanyService.GetFromIdPair(JobHistory.Id, Company.Id);
            Assert.AreEqual(added.Id, JobHistoryCompany.Id);
        }

        [Test]
        public void RemoveTest()
        {
            JobHistoryCompanyService.Remove(JobHistory.Id, Company.Id);
            var removed = JobHistoryCompanyService.GetFromIdPair(JobHistory.Id, Company.Id);
            Assert.AreEqual(removed.Id, -1);
        }
    }
}
