using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.AddressCandidateService
{
    public class AddressCandidateServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public IAddressCandidateService AddressCandidateService { get; set; }
        public AddressService.AddressService AddressService { get; set; }
        public EmployeeService.CandidateService CandidateService { get; set; }
        public Address_Candidate AddressCandidate { get; set; }
        public Address Address { get; set; }
        public Candidate Candidate { get; set; }

        public AddressCandidateServiceTest()
        {
            TecAppContext = new TecAppContext();
            AddressCandidateService = new AddressCandidateService(TecAppContext);
            AddressService = new AddressService.AddressService(TecAppContext);
            CandidateService = new EmployeeService.CandidateService(TecAppContext);
        }

        [Test]
        public void AddTest()
        {
            var random = new Random();

            var randomAddress = AddressService.AddAddress(new Address());
            var randomCandidate = CandidateService.AddCandidate(new Candidate());
            var newAddressCandidate=  new Address_Candidate()
            {
                Candidate = randomCandidate,
                Address =  randomAddress
            };
            AddressCandidate = AddressCandidateService.Add(newAddressCandidate);
            Address = AddressCandidate.Address;
            Candidate = AddressCandidate.Candidate;

        }

        [Test]
        public void GetTest()
        {
            var addressCandidate = AddressCandidateService.GetFromAddressAndCandidateId(Address.Id, Candidate.Id);
            Assert.AreEqual(addressCandidate.AddressId, Address.Id);
            Assert.AreEqual(addressCandidate.CandidateId, Candidate.Id);
            Assert.AreEqual(addressCandidate.Id, AddressCandidate.Id);
        }

        [Test]
        public void RemoveTest()
        {
            AddressCandidateService.Remove(AddressCandidate.AddressId, AddressCandidate.CandidateId);
            var removedAddressCandidate =
                AddressCandidateService.GetFromAddressAndCandidateId(AddressCandidate.AddressId,
                    AddressCandidate.CandidateId);
            Assert.AreEqual(removedAddressCandidate.Id, -1);

            AddressService.RemoveAddress(Address);
            CandidateService.RemoveCandidate(Candidate);
        }
    }
}
