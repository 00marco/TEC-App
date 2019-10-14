using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.OpeningsService
{
    public class OpeningServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public IOpeningsService OpeningsService { get; set; }
        public Opening Opening { get; set; }

        public OpeningServiceTest()
        {
            TecAppContext= new TecAppContext();
            OpeningsService = new OpeningsService(TecAppContext);
        }

        [Test]
        public void GetAllOpeningsTest()
        {
            var openings = OpeningsService.GetAllOpenings();
            foreach (var v in openings)
            {
                Console.WriteLine();
                Console.WriteLine($"Company Name\t\t{v.Company.Name}");
                Console.WriteLine($"Reqd Qualifications\t{v.RequiredQualification.Code}");
                Console.WriteLine($"Placement Count\t{v.Placements.Count}");
                Console.WriteLine($"DateTime Start\t{v.DateTimeStart}");
                Console.WriteLine($"DateTime End\t{v.DateTimeEnd}");
                Console.WriteLine($"Hourly Pay\t\t{v.HourlyPay}");
                Console.WriteLine();
            }
        }

        //[TestCase(1, 77f)]
        //[TestCase(2, 23f)]
        //[TestCase(3, 75f)]
        //[TestCase(4, 56f)]
        //[TestCase(5, 76f)]
        public void GetOpeningFromIdTest(int id, float result)
        {
            var opening = OpeningsService.GetOpeningFromId(id);
            Assert.AreEqual(opening.HourlyPay, result);
        }

        [Test]
        public void AddOpeningTest()
        {
            var random = new Random();
            var newOpening = new Opening()
            {
                DateTimeStart = DateTime.Now,
                DateTimeEnd = DateTime.Now.AddDays(5),
                Company = new Company(),
                HourlyPay = random.Next(),
                Placements = new List<Placement>(),
                RequiredQualification = new Qualification(),
                Job = new Job()
                
            };
            Opening = OpeningsService.AddOpening(newOpening);
        }

        [Test]
        public void Y_TestAddedOpening()
        {
            var addedOpening = OpeningsService.GetOpeningFromId(Opening.Id);
            Assert.AreEqual(addedOpening.HourlyPay, Opening.HourlyPay);
        }

        [Test]
        public void Z_RemoveOpeningTest()
        {
            OpeningsService.RemoveOpening(Opening);
            var removedOpening = OpeningsService.GetOpeningFromId(Opening.Id);
            Assert.AreEqual(removedOpening.Id, -1);
        }
    }
}
