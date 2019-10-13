using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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


        public List<Company> GetAllCompanies()
        {
            return _context.Set<Company>()
                .Include(c => c.Openings)
                .Include(c=>c.JobHistory_Company_Pairs)
                .ToList();
        }

        public Company GetCompanyFromId(int id)
        {
            return GetAllCompanies().FirstOrDefault(d => d.Id == id);
        }
    }
}
