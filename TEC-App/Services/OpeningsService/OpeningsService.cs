using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Models.ViewDTO;

namespace TEC_App.Services.OpeningsService
{
    public class OpeningsService : IOpeningsService
    {
        private readonly TecAppContext context;

        public OpeningsService(TecAppContext context)
        {
            this.context = context;
        }
        public Opening GetOpeningFromId(int id)
        {
            return GetAllOpenings().FirstOrDefault(d => d.Id == id);
        }

        public List<Opening> GetAllOpenings()
        {
                var openings = context.Set<Opening>()
                    .Include(c => c.RequiredQualification)
                    .Include(c => c.Company)
                    .Include(c => c.Job)
                    .Include(c=>c.Placements)
                    .ToList();
                return openings;
            
        }

        public void AddOpening(Opening opening)
        {
            context.Openings.Add(opening);
            context.SaveChanges();
        }
    }
}
