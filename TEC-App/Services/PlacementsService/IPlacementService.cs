using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;

namespace TEC_App.Services.PlacementsService
{
    public interface IPlacementService
    {
        List<Placement> GetAllPlacements();
        Placement GetPlacementFromId(int id);
        void RemovePlacement(Placement placement);
        Placement AddPlacement(Placement placement);
    }
}
