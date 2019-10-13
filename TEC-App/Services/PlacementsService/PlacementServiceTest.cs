using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Services.EmployeeService;
using TEC_App.Services.OpeningsService;

namespace TEC_App.Services.PlacementsService
{
    public class PlacementServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public IPlacementService PlacementService { get; set; }
        public IOpeningsService OpeningsService { get; set; }
        public ICandidateService CandidateService { get; set; }
        public Placement Placement { get; set; }



        public PlacementServiceTest()
        {
            TecAppContext = new TecAppContext();
            PlacementService = new PlacementService(TecAppContext);
            OpeningsService = new OpeningsService.OpeningsService(TecAppContext);
            CandidateService = new EmployeeService.CandidateService(TecAppContext);
        }

        [Test]
        public void GetAllPlacementsTest()
        {
            var placements = PlacementService.GetAllPlacements();
            foreach (var v in placements)
            {
                Console.WriteLine();
                Console.WriteLine($"{v.Opening.Id}");
                Console.WriteLine($"{v.Candidate.Id}");
                Console.WriteLine($"{v.TotalHoursWorked}");
                Console.WriteLine($"{v.Timestamp}");
                Console.WriteLine();
            }
        }

        [TestCase(1, 193)]
        [TestCase(2, 130)]
        [TestCase(3, 31)]
        [TestCase(4, 9)]
        public void GetPlacementFromIdTest(int id, float result)
        {
            var placement = PlacementService.GetPlacementFromId(id);
            Assert.AreEqual(placement.TotalHoursWorked, result);
        }

        [Test]
        public void AddPlacementTest()
        {
            var random = new Random();
            var candidates = CandidateService.GetAllCandidates();
            var openings = OpeningsService.GetAllOpenings();
            var randomCandidate = candidates[random.Next(999)];
            var randomOpening = openings[random.Next(999)];
            var newPlacement = new Placement()
            {
                Timestamp = DateTime.Now,
                Candidate = randomCandidate,
                Opening = randomOpening,
                CandidateId = randomCandidate.Id,
                OpeningId = randomOpening.Id,
                TotalHoursWorked = random.Next(),
            };
            Placement = PlacementService.AddPlacement(newPlacement);
        }

        [Test]
        public void Y_TestAddedPlacement()
        {
            var addedPlacement = PlacementService.GetPlacementFromId(Placement.Id);
            Assert.AreEqual(addedPlacement.TotalHoursWorked, Placement.TotalHoursWorked);
        }

        [Test]
        public void Z_RemovePlacement()
        {
            PlacementService.RemovePlacement(Placement);
            var removedPlacement = PlacementService.GetPlacementFromId(Placement.Id);
            Assert.AreEqual(removedPlacement.Id, -1);
        }
    }
}
