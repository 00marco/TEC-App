using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;

namespace TEC_App.Services.JobHistoryService
{
    public class JobHistoryServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public IJobHistoryService JobHistoryService { get; set; }

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
    }
}
