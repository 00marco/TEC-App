using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Services.PlacementService
{
    public interface IPlacementService
    {
        Placement GetPlacementFromId(int id);
        List<Placement> GetAllPlacements();
        Placement AddPlacement(Placement placement);
        void RemovePlacement(Placement placement);
    }
}
