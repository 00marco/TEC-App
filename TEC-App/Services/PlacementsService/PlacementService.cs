using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;

namespace TEC_App.Services.PlacementsService
{
    public class PlacementService : IPlacementService
    {
        public PlacementService(TecAppContext _context)
        {
            context = _context;
        }

        public readonly TecAppContext context;
        public List<Placement> GetAllPlacements()
        {
            var placements = context.Set<Placement>()
                .Include(c => c.Opening)
                .ThenInclude(c=>c.Company)
                .Include(c => c.Candidate)
                .ToList();
            return placements;
        }


        public Placement GetPlacementFromId(int id )
        {
            var placement = GetAllPlacements().FirstOrDefault(d => d.Id == id);
            if (placement == null)
            {
                return new Placement()
                {
                    Id = -1
                };
            }

            return placement;
        }

        public void RemovePlacement(Placement placement)
        {
            context.Remove(context.Placements.Single(d => d.Id == placement.Id));
            context.SaveChanges();
        }

        public Placement AddPlacement(Placement placement)
        {
            context.Placements.Add(placement);
            context.SaveChanges();
            return placement;
        }
    }
}
