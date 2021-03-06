﻿using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Views.OpeningsView;

namespace TEC_App.Services.OpeningsService
{
    public interface IOpeningsService
    {
        Opening GetOpeningFromId(int id);
        List<Opening> GetAllOpenings();
        List<OpeningViewDTO> GetAllOpeningsAsViewDtos();
        Opening AddOpening(Opening opening);
        void RemoveOpening(Opening opening);
        void CloseOpening(Opening opening);
    }
}
