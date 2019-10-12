using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
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


        public List<CompanyWithOpeningDetailsDTO> GetCompanyWithOpeningDetailsDtoList()
        {
            //throw new NotImplementedException();
            var openings = GetOpenings();
            var dtos = new List<CompanyWithOpeningDetailsDTO>();
            foreach (var v in openings)
            {
                dtos.Add(new CompanyWithOpeningDetailsDTO()
                {
                    StartDate = v.DateTimeStart,
                    EndDate = v.DateTimeEnd,
                    OpeningName = v.Id+"",
                    CompanyName = v.Company.Name,
                    RequiredQualifications = v.RequiredQualification.Code,
                    HourlyPay = v.HourlyPay
                });
            }

            return dtos;
        }
        public List<OpeningViewDTO> GetOpeningViewDTOList()
        {
            var dbDtos = GetCompanyWithOpeningDetailsDtoList();
            var viewDtos = new List<OpeningViewDTO>();
            foreach (var v in dbDtos)
            {
                viewDtos.Add(new OpeningViewDTO(){CompanyWithOpeningDetailsDto = v});
            }

            return viewDtos;
        }

        public List<Opening> GetOpenings()
        {
                var openings = _context.Set<Opening>()
                    .Include(c => c.RequiredQualification)
                    .Include(c => c.Company)
                    .Include(c => c.Job)
                    .ToList();
                return openings;
            
        }

        public List<Opening> GetUniqueOpenings()
        {
            throw new NotImplementedException();
        }
    }
}
