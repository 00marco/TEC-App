using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Views.CompaniesView;

namespace TEC_App.Services.CompanyService.QueryObjects
{
    public static class CompanyViewDtoSelect
    {
        public static IQueryable<CompanyViewDTO> MapCompanyToDto(this IQueryable<Company> companies)
        {
            return companies.Select(company => new CompanyViewDTO()
            {
                Company = company
            });
        }
    }
}
