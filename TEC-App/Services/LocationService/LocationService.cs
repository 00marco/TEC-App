using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.LocationService
{
    public class LocationService : ILocationService
    {
        public readonly TecAppContext context;

        public LocationService(TecAppContext context)
        {
            this.context = context;
        }
        public List<Location> GetAllLocations()
        {
            return context.Set<Location>()
                .Include(d => d.Address)
                .Include(d => d.Session_Location_Pairs)
                .ToList();
        }

        public Location GetLocationFromId(int id)
        {
            var location =  GetAllLocations().FirstOrDefault(d => d.Id == id);
            if (location == null)
            {
                return new Location()
                {
                    Id = -1
                };
            }

            return location;
        }

        public Location AddLocation(Location location)
        {
            context.Locations.Add(location);
            context.SaveChanges();
            return location;
        }

        public void RemoveLocation(Location location)
        {
            context.Remove(context.Locations.Single(d => d.Id == location.Id));
            context.SaveChanges();
        }
    }
}
