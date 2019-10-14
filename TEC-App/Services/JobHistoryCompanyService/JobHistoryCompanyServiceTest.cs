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
        public bool End { get; set; }


        public JobHistoryCompanyServiceTest()
        {
            TecAppContext = new TecAppContext();
            JobHistoryService = new JobHistoryService.JobHistoryService(TecAppContext);
            CompanyService = new CompanyService.CompanyService(TecAppContext);
            JobHistoryCompanyService = new JobHistoryCompanyService(TecAppContext);
            End = false;
        }

        [Test]
        public void AddTest()
        {
            var random = new Random();
            var count = JobHistoryService.GetAllJobHistories().Count;
            var allJobHistories = JobHistoryService.GetAllJobHistories();
            if (count == 0)
            {
                End = true;
                return;
            }
            JobHistory = allJobHistories[random.Next(count)];
            Company = CompanyService.GetAllCompanies()[random.Next(CompanyService.GetAllCompanies().Count)];
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
            if (End) return;
            var added = JobHistoryCompanyService.GetFromIdPair(JobHistory.Id, Company.Id);
            Assert.AreEqual(added.Id, JobHistoryCompany.Id);
        }

        [Test]
        public void RemoveTest()
        {
            if (End) return;
            JobHistoryCompanyService.Remove(JobHistory.Id, Company.Id);
            var removed = JobHistoryCompanyService.GetFromIdPair(JobHistory.Id, Company.Id);
            Assert.AreEqual(removed.Id, -1);

        }
    }
}
