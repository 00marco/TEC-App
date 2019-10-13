using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;

namespace TEC_App.Services.LocationService
{
    public class LocationServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public ILocationService LocationService { get; set; }

        public LocationServiceTest()
        {
            TecAppContext = new TecAppContext();
            LocationService = new LocationService(TecAppContext);
        }

        [Test]
        public void GetAllLocations()
        {
            var locations = LocationService.GetAllLocations();
            foreach (var v in locations)
            {
                Console.WriteLine();
                Console.WriteLine($"{v.Address.Id}");
                Console.WriteLine($"{v.Session_Location_Pairs.Count}");
                Console.WriteLine($"{v.Id}");
                Console.WriteLine();
            }
        }

        [TestCase(1, 892)]
        [TestCase(2, 70)]
        [TestCase(3, 555)]
        [TestCase(4, 290)]
        public void GetLocationFromId(int id, int result)
        {
            var location = LocationService.GetLocationFromId(id);
            Assert.AreEqual(location.AddressId, result);
        }
    }
}
