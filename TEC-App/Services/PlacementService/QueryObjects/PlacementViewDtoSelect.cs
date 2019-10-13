using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;
using TEC_App.Models.ViewDTO;

namespace TEC_App.Services.PlacementService.QueryObjects
{
    public static class PlacementViewDtoSelect
    {
        public static IQueryable<PlacementViewDTO> MapPlacementToDtos(this IQueryable<Placement> placements)
        {
            return placements.Select(placement => new PlacementViewDTO()
            {
                Placement = placement
            });
        }
    }
}
