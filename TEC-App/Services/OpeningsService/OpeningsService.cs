using System.Collections.Generic;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Models.ViewDTO;

namespace TEC_App.Services.OpeningsService
{
    public class OpeningsService : IOpeningsService
    {
        private readonly TecAppContext _context;

        public OpeningsService(TecAppContext context)
        {
            _context = context;
        }
        public Opening GetOpeningFromId(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<OpeningViewDTO> GetOpeningViewDTOList()
        {
            return new List<OpeningViewDTO>();
        }
    }
}
