using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.ViewDTO;

namespace TEC_App.Services.OpeningsService
{
    public interface IOpeningsService
    {
        Opening GetOpeningFromId(int id);
        List<OpeningViewDTO> GetOpeningViewDTOList();
        //TODO Fix this. You should only have GetOpenings - you need a function to map the resulting openings to a dto
    }
}
