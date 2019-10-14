using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.JobService
{
    public class JobServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public IJobService JobService { get; set; }
        public Job Job { get; set; }

        public JobServiceTest()
        {
            TecAppContext = new TecAppContext();
            JobService = new JobService(TecAppContext);
        }

        [Test]
        public void GetAllJobsTest()
        {
            var jobs = JobService.GetAllJobs();
            foreach (var v in jobs)
            {
                Console.WriteLine();
                Console.WriteLine($"Name\t\t{v.Name}");
                Console.WriteLine($"JobHistCount\t{v.JobHistory_Job_Pairs}");
                Console.WriteLine($"OpeningCount\t{v.Openings}");
                Console.WriteLine();
            }
        }

        //[TestCase(1, "Dental Hygienist")]
        //[TestCase(2, "Marketing Assistant")]
        //[TestCase(3, "Web Developer IV")]
        //[TestCase(4, "Paralegal")]
        public void GetJobFromId(int id, string result)
        {
            var job = JobService.GetJobFromId(id);
            Assert.AreEqual(job.Name,result);

        }

        [Test]
        public void AddJobTest()
        {
            var random = new Random();
            var newJob = new Job()
            {
                Name = $"Job-{random.Next()}"
            };
            Job = JobService.AddJob(newJob);
        }

        [Test]
        public void Y_TestAddedJob()
        {
            var addedJob = JobService.GetJobFromId(Job.Id);
            Assert.AreEqual(addedJob.Name, Job.Name);
        }

        [Test]
        public void Z_RemoveJob()
        {
            JobService.RemoveJob(Job);
            var removedJob = JobService.GetJobFromId(Job.Id);
            Assert.AreEqual(removedJob.Id, -1);
        }
    }
}
