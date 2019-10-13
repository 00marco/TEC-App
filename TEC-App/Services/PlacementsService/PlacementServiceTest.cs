using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;

namespace TEC_App.Services.PlacementsService
{
    public class PlacementServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public IPlacementService PlacementService { get; set; }

        public PlacementServiceTest()
        {
            TecAppContext = new TecAppContext();
            PlacementService = new PlacementService(TecAppContext);
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
    }
}
