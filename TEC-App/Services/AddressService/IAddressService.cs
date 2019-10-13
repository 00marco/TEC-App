using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Services.AddressService
{
    public interface IAddressService
    {
        List<Address> GetAllAdresses();
        Address GetAddressFromId(int id);
        Address AddAddress(Address address);
        void RemoveAddress(Address address);
    }
}
