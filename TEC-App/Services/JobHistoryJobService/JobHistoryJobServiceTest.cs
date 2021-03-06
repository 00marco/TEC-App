﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.JobHistoryJobService
{
    public class JobHistoryJobServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public JobHistoryJobService JobHistoryJobService { get; set; }
        public JobHistoryService.JobHistoryService JobHistoryService { get; set; }
        public JobService.JobService JobService { get; set; }
        public Job Job { get; set; }
        public JobHistory JobHistory { get; set; }
        public JobHistory_Job JobHistoryJob { get; set; }
        public bool End { get; set; }


        public JobHistoryJobServiceTest()
        {
            TecAppContext = new TecAppContext();
            JobHistoryJobService = new JobHistoryJobService(TecAppContext);
            JobHistoryService = new JobHistoryService.JobHistoryService(TecAppContext);
            JobService = new JobService.JobService(TecAppContext);
            End = false;
        }

        [Test]
        public void AddTest()
        {
            var random = new Random();
            if (JobHistoryService.GetAllJobHistories().Count == 0)
            {
                End = true;
                return;
            }
            Job = JobService.GetAllJobs()[random.Next(JobService.GetAllJobs().Count)];
            JobHistory = JobHistoryService.GetAllJobHistories()[random.Next(JobHistoryService.GetAllJobHistories().Count)];
            JobHistoryJob = JobHistoryJobService.Add(new JobHistory_Job()
            {
                Job = Job,
                JobId = Job.Id,
                JobHistory = JobHistory,
                JobHistoryId = JobHistory.Id
            });

        }

        [Test]
        public void GetTest()
        {
            if (End) return;
            var added = JobHistoryJobService.GetFromIdPair(JobHistory.Id, Job.Id);
            Assert.AreEqual(added.Id, JobHistoryJob.Id);

        }

        [Test]
        public void RemoveTest()
        {
            if (End) return;
            JobHistoryJobService.Remove(JobHistory.Id, Job.Id);
            var removed = JobHistoryJobService.GetFromIdPair(JobHistory.Id, Job.Id);
            Assert.AreEqual(removed.Id, -1);

        }

    }
}
