using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.JobHistoryService
{
    public class JobHistoryServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public IJobHistoryService JobHistoryService { get; set; }
        public JobHistory JobHistory { get; set; }

        public JobHistoryServiceTest()
        {
            TecAppContext = new TecAppContext();
            JobHistoryService = new JobHistoryService(TecAppContext);
        }

        [Test]
        public void GetAllJobHistoriesTest()
        {
            var jobHistories = JobHistoryService.GetAllJobHistories();
            foreach (var v in jobHistories)
            {
                Console.WriteLine();
                Console.WriteLine($"{v.Candidate.FullName}");
                Console.WriteLine($"{v.JobHistory_Company_Pairs.Count}");
                Console.WriteLine($"{v.JobHistory_Job_Pairs.Count}");
                Console.WriteLine($"{v.Id}");
                Console.WriteLine();
            }
        }

        [TestCase(1, 559)]
        [TestCase(2, 523)]
        [TestCase(3, 917)]
        [TestCase(4, 43)]
        public void GetJobHistoryFromIdTest(int id, int result)
        {
            var jobHistory = JobHistoryService.GetJobHistoryFromId(id);
            Assert.AreEqual(jobHistory.Candidate.Id, result);
        }

        [Test]
        public void AddJobHistoryTest()
        {
            var random = new Random();
            var newJobHistory = new JobHistory()
            {
                Candidate = new Candidate(),
                DateTimeStart = DateTime.Now,
                DateTimeEnd = DateTime.Now.AddDays(5),
                JobHistory_Company_Pairs = new List<JobHistory_Company>(),
                JobHistory_Job_Pairs = new List<JobHistory_Job>()
            };
            JobHistory = JobHistoryService.AddJobHistory(newJobHistory);
        }

        [Test]
        public void Y_TestAddedJobHistory()
        {
            var addedJobHistory = JobHistoryService.GetJobHistoryFromId(JobHistory.Id);
            Assert.AreEqual(addedJobHistory.DateTimeStart, JobHistory.DateTimeStart);
            Assert.AreEqual(addedJobHistory.DateTimeEnd, JobHistory.DateTimeEnd);
        }

        [Test]
        public void Z_RemoveJobHistoryTest()
        {
            JobHistoryService.RemoveJobHistory(JobHistory);
            var removedJobHistory = JobHistoryService.GetJobHistoryFromId(JobHistory.Id);
            Assert.AreEqual(removedJobHistory.Id, -1);
        }
    }
}
