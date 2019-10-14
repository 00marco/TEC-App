using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Services.EmployeeService;
using TEC_App.Services.OpeningsService;

namespace TEC_App.Services.CandidateService
{
    public class CandidateServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public Candidate Candidate { get; set; }
        public ICandidateService CandidateService { get; set; }
        public IOpeningsService OpeningsService { get; set; }

        public CandidateServiceTest()
        {
            TecAppContext = new TecAppContext();
            OpeningsService = new OpeningsService.OpeningsService(TecAppContext);
            CandidateService = new EmployeeService.CandidateService(TecAppContext);
        }

        [Test]
        public void GetAllCandidatesTest()
        {
            var candidates = CandidateService.GetAllCandidates();
            foreach (var v in candidates)
            {
                Console.WriteLine();
                Console.WriteLine($"FullName\t\t\t\t{v.FullName}");
                Console.WriteLine($"AddressCount\t\t\t\t{v.Addresses.Count}");
                Console.WriteLine($"CandidateSessionCount\t\t\t{v.Candidate_Session_Pairs.Count}");
                Console.WriteLine($"CandidateQualificationsCount\t\t{v.CandidateQualifications.Count}");
                Console.WriteLine($"JobHistoriesCount\t\t\t{v.JobHistories.Count}");
                Console.WriteLine($"PlacementsCount\t\t\t\t{v.Placements.Count}");
                Console.WriteLine($"TimeStamp\t\t\t\t{v.Timestamp}");
                Console.WriteLine();
            }
        }

        [TestCase(1, "Dorthea")]
        [TestCase(2, "Farah")]
        [TestCase(3, "Cairistiona")]
        [TestCase(4, "Uriel")]
        public void GetCandidateFromIdTest(int id, string result)
        {
            var candidate = CandidateService.GetCandidateFromId(id);
            Assert.AreEqual(candidate.FirstName, result);
        }

        [Test]
        public void AddCandidateTest()
        {
            var random = new Random();
            var newCandidate = new Candidate()
            {
                CandidateQualifications = new List<Candidate_Qualification>(),
                Addresses = new List<Address_Candidate>(),
                Candidate_Session_Pairs = new List<Candidate_Session>(),
                JobHistories = new List<JobHistory>(),
                Placements = new List<Placement>(),
                Timestamp = DateTime.Now,
                FirstName = "FName",
                MiddleName = "MName",
                LastName = $"{random.Next(5000)}"
            };
            Candidate = CandidateService.AddCandidate(newCandidate);

        }
        [Test]
        public void Y_TestAddedCompany()
        {
            var candidate = CandidateService.GetCandidateFromId(Candidate.Id);
            Assert.AreEqual(candidate.FirstName, Candidate.FirstName);
        }

        [Test]
        public void Z_RemoveCompanyTest()
        {
            CandidateService.RemoveCandidate(Candidate);
            var removedCandidate = CandidateService.GetCandidateFromId(Candidate.Id);
            Assert.AreEqual(removedCandidate.Id, -1);
        }

        [Test]
        public void GetCandidatesQualifiedForOpeningTest()
        {
            var random = new Random();
            var allOpenings = OpeningsService.GetAllOpenings();
           
            foreach (var x in allOpenings)
            {
                var candidatesQualifiedForOpening = CandidateService.GetCandidatesQualifiedForRequiredQualification(x.Id);
                Console.WriteLine();
                Console.WriteLine($"Job\t{x.Job.Name}");
                Console.WriteLine("--------------------------");
                foreach (var v in candidatesQualifiedForOpening)
                {
                    Console.WriteLine($"Name\t-{v.FullName}");
                }
                Console.WriteLine();
            }
        }
    }
}
