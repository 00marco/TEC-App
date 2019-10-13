using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Models.ViewDTO;
using TEC_App.Services.PlacementService.QueryObjects;

namespace TEC_App.Services.PlacementService
{
    public class PlacementService : IPlacementService
    {
        public readonly TecAppContext context;

        public PlacementService(TecAppContext context)
        {
            this.context = context;
        }
        public Placement GetPlacementFromId(int id)
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

        public List<Placement> GetAllPlacements()
        {
            return context.Set<Placement>()
                .Include(d => d.Opening)
                .ThenInclude(d=>d.Job)
                .Include(d => d.Candidate)
                .ToList();
        }

        public List<PlacementViewDTO> GetAllPlacementViewDtos()
        {
            return context.Set<Placement>()
                .Include(d => d.Opening)
                .ThenInclude(d=>d.Job)
                .Include(d => d.Candidate)
                .MapPlacementToDtos()
                .ToList();
        }

        public Placement AddPlacement(Placement placement)
        {
            context.Placements.Add(placement);
            context.SaveChanges();
            return placement;
        }

        public void RemovePlacement(Placement placement)
        {
            context.Remove(context.Placements.Single(d => d.Id == placement.Id));
            context.SaveChanges();
        }

    }
}
