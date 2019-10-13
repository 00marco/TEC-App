using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;
using TEC_App.Models.ViewDTO;

namespace TEC_App.Services.OpeningsService.QueryObjects
{
    public static class OpeningViewDtoSelect
    {
        public static IQueryable<OpeningViewDTO> MapOpeningToDto(this IQueryable<Opening> openings)
        {
            return openings.Select(opening =>
                new OpeningViewDTO()
                {
                    Opening = opening
                });
        }
    }
}
