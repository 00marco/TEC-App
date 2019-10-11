using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Models.ViewDTO;

namespace TEC_App.Services.OpeningsService
{
    public static class OpeningViewDTOSelect
    {
		public static IQueryable<OpeningViewDTO> MapOpeningToDto(this IQueryable<Opening> books)
		{
		//public string CompanyName { get; set; }
		//public string OpeningName { get; set; }
		//public string RequiredQualifications { get; set; }
		//public DateTime StartDate { get; set; }
		//public DateTime EndDate { get; set; }
		//public float HourlyPay { get; set; }
		throw new NotImplementedException();
		}

	}
}
