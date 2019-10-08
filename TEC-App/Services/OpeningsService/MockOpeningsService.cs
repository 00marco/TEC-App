using System;
using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Models.ViewDTO;

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


		public List<OpeningViewDTO> GetOpeningViewDTOList()
        {
            var openings = new List<OpeningViewDTO>();
            var opening1 = new CompanyWithOpeningDetailsDTO()
            {
                CompanyName = "Company 1",
                EndDate = DateTime.Now.AddDays(2),
                StartDate = DateTime.Now,
                HourlyPay = 10,
                OpeningName = "Opening 1",
                RequiredQualifications = "A,B,C"

            };
            var opening2 = new CompanyWithOpeningDetailsDTO()
            {
                CompanyName = "Company 2",
                EndDate = DateTime.Now.AddDays(2),
                StartDate = DateTime.Now,
                HourlyPay = 10,
                OpeningName = "Opening 2",
                RequiredQualifications = "D,E,F"

            };
            openings.Add(new OpeningViewDTO()
            {
                CompanyWithOpeningDetailsDto = opening1
            });
            openings.Add(new OpeningViewDTO()
            {
                CompanyWithOpeningDetailsDto = opening2
            });
            return openings;
        }
    }
}
