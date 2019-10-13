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

namespace TEC_App.Services.PlacementService
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
        }

        [Test]
        public void AddPlacementTest()
        {
            var random = new Random();
            var randomOpening = OpeningsService.GetAllOpenings()[random.Next(999)];
            var randomCandidate = CandidateService.GetAllCandidates()[random.Next(999)];
            var newPlacement = new Placement()
            {
                Opening = randomOpening,
                Candidate =  randomCandidate,
                CandidateId = randomCandidate.Id,
                OpeningId = randomOpening.Id,
                Timestamp = DateTime.Now,
                TotalHoursWorked = random.Next()
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
        public void Z_RemovePlacementTest()
        {
            PlacementService.RemovePlacement(Placement);
            var removedPlacement = PlacementService.GetPlacementFromId(Placement.Id);
            Assert.AreEqual(removedPlacement.Id, -1);
        }
    }
}
