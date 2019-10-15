using System;
using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Views.OpeningsView;

namespace TEC_App.Services.OpeningsService
{
    public class MockOpeningsService : IOpeningsService
    {
        public Opening GetOpeningFromId(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Opening> GetUniqueOpenings()
        {
throw new NotImplementedException();        }

        public List<OpeningViewDTO> GetAllOpeningsAsViewDtos()
        {
            throw new NotImplementedException();
        }

        public Opening AddOpening(Opening opening)
        {
            throw new NotImplementedException();
        }

        public void RemoveOpening(Opening opening)
        {
            throw new NotImplementedException();
        }


        public List<OpeningViewDTO> GetOpeningViewDTOList()
        {
            throw new NotImplementedException();
            ;
        }

        public List<Opening> GetAllOpenings()
        {
            throw new NotImplementedException();
        }
    }
}
