using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.AddressService
{
    public class AddressService : IAddressService
    {
        public readonly TecAppContext context;

        public AddressService(TecAppContext context)
        {
            this.context = context;
        }
        public List<Address> GetAllAdresses()
        {
            return context.Set<Address>()
                .Include(d => d.Address_Candidate_Pairs)
                .Include(d => d.Locations)
                .ToList();
        }

        public Address GetAddressFromId(int id)
        {
            var address = GetAllAdresses().FirstOrDefault(d => d.Id == id);
            if (address == null)
            {
                return new Address()
                {
                    Address_Candidate_Pairs = null,
                    Locations = null,
                    City = null,
                    Province = null,
                    Street = null,
                    ZipCode = null,
                    Id = -1
                };

            }
            else
            {
                return address;
            }
        }

        public Address AddAddress(Address address)
        {
            context.Addresses.Add(address);
            context.SaveChanges();
            return address;
        }

        public void RemoveAddress(Address address)
        {
            context.Remove(context.Addresses.Single(d => d.Id == address.Id));
            context.SaveChanges();
        }
    }
}
