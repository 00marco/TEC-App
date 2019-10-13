using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.ViewDTO;

namespace TEC_App.Services.OpeningsService
{
    public interface IOpeningsService
    {
        Opening GetOpeningFromId(int id);
        List<Opening> GetAllOpenings();
        void AddOpening(Opening opening);

    }
}
