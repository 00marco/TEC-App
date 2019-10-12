using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;

namespace TEC_App.Services.PlacementsService
{
    public class PlacementService : IPlacementService
    {
        public PlacementService(TecAppContext _context)
        {
            context = _context;
        }

        public readonly TecAppContext context;
        public List<Placement> GetPlacement()
        {
            var placements = context.Set<Placement>()
                .Include(c => c.Opening)
                .ThenInclude(c=>c.Company)
                .Include(c => c.Candidate)
                .ToList();
            return placements;
        }

        public List<PlacementWithCandidateDTO> GetPlacementWithCandidateDtos()
        {
            var placements = GetPlacement();
            var placementWithCandidateDtos = new List<PlacementWithCandidateDTO>();
            foreach (var v in placements)
            {
                placementWithCandidateDtos.Add(new PlacementWithCandidateDTO()
                {
                    CandidateName = v.Candidate.FullName,
                    CompanyName = v.Opening.Company.Name,
                    DateTimeStart = v.Opening.DateTimeStart,
                    DateTimeEnd = v.Opening.DateTimeEnd,
                    HoursWorked = v.TotalHoursWorked,
                    Payment = v.Opening.HourlyPay * v.TotalHoursWorked //TODO ??? might want to change this
                });
            }

            return placementWithCandidateDtos;
        }
    }
}
