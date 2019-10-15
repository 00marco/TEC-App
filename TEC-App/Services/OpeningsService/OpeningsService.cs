using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Services.OpeningsService.QueryObjects;
using TEC_App.Views.OpeningsView;

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
            var opening = GetAllOpenings().FirstOrDefault(d => d.Id == id);
            if (opening == null)
            {
                return new Opening()
                {
                    Id = -1

                };
            }

            return opening;
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

        public List<OpeningViewDTO> GetAllOpeningsAsViewDtos()
        {
            var openingViewDtos = context.Set<Opening>()
                .Include(c => c.RequiredQualification)
                .Include(c => c.Company)
                .Include(c => c.Job)
                .Include(c => c.Placements)
                .MapOpeningToDto()
                .ToList();
            return openingViewDtos;
        }

        public Opening AddOpening(Opening opening)
        {
            context.Openings.Add(opening);
            context.SaveChanges();
            return opening;
        }

        public void RemoveOpening(Opening opening)
        {
            context.Remove(context.Openings.Single(d => d.Id == opening.Id));
            context.SaveChanges();
        }
    }
}
