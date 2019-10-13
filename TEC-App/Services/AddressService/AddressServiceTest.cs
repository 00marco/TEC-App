using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;

namespace TEC_App.Services.AddressService
{
    public class AddressServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public IAddressService AddressService { get; set; }

        public AddressServiceTest()
        {
            TecAppContext = new TecAppContext();
            AddressService = new AddressService(TecAppContext);
        }

        [Test]
        public void GetAllAddressesTest()
        {
            var addresses = AddressService.GetAllAdresses();
            foreach (var v in addresses)
            {
                Console.WriteLine();
                Console.WriteLine($"{v.Address_Candidate_Pairs.Count}");
                Console.WriteLine($"{v.Locations.Count}");
                Console.WriteLine();
            }
        }

        [TestCase(1, "Texas")]
        [TestCase(2, "Wyoming")]
        [TestCase(3, "Indiana")]
        [TestCase(4, "Texas")]
        public void GetAddressFromIdTest(int id, string result)
        {
            var address = AddressService.GetAddressFromId(id);
            Assert.AreEqual(address.Province, result);
        }
    }
}
