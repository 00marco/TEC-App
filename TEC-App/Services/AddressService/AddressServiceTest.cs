using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.AddressService
{
    public class AddressServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public IAddressService AddressService { get; set; }
        public Address Address { get; set; }
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

        //[TestCase(1, "Texas")]
        //[TestCase(2, "Wyoming")]
        //[TestCase(3, "Indiana")]
        //[TestCase(4, "Texas")]
        //[TestCase(9999, null)]
        public void GetAddressFromIdTest(int id, string result)
        {
            var address = AddressService.GetAddressFromId(id);
            Assert.AreEqual(address.Province, result);
        }

        [Test]
        public void AddAddressTest()
        {
            var random = new Random();
            var newAddress = new Address()
            {
                Address_Candidate_Pairs = new List<Address_Candidate>(),
                City = $"City-{random.Next(100)}",
                Province = $"Province-{random.Next(100)}",
                Street = $"Street-{random.Next(100)}",
                ZipCode = $"ZipCode-{random.Next(100)}",
                Locations = new List<Location>()
            };
            Address = AddressService.AddAddress(newAddress);
        }

        [Test]
        public void Y_TestAddedAddress()
        {
            var address = AddressService.GetAddressFromId(Address.Id);
            Assert.AreEqual(address.Province, Address.Province);
        }

        [Test]
        public void Z_RemoveAddressTest()
        {
            AddressService.RemoveAddress(Address);
            var removedAddress = AddressService.GetAddressFromId(Address.Id);
            Assert.AreEqual(removedAddress.Id, -1);
        }

    }
}
