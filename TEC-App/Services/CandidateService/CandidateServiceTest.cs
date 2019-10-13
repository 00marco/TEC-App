using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Services.EmployeeService;

namespace TEC_App.Services.CandidateService
{
    public class CandidateServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public ICandidateService CandidateService { get; set; }

        public CandidateServiceTest()
        {
            TecAppContext = new TecAppContext();
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
    }
}
