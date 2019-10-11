using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;

namespace TEC_App.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly TecAppContext _context;

        public CompanyService(TecAppContext context)
        {
            _context = context;
        }


        public List<Company> GetCompanies()
        {
            return _context.Set<Company>()
                .Include(c => c.Openings)
                .Include(c=>c.JobHistory_Company_Pairs)
                .ToList();
        }

        public List<CompanyViewDTO> GetCompanyViewDtos()
        {
            var list = _context.Set<Company>()
                .ToList();
            var companyViewDtos = new List<CompanyViewDTO>();
            foreach (var v in list)
            {
                companyViewDtos.Add(new CompanyViewDTO()
                {
                    CompanyNAme = v.Name,
                });
            }

            return companyViewDtos;
        }
    }
}
