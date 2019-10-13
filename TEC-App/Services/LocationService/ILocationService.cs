using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Services.LocationService
{
    public interface ILocationService
    {
        List<Location> GetAllLocations();
        Location GetLocationFromId(int id);
    }
}
