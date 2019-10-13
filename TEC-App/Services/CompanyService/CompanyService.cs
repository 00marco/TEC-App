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
        private readonly TecAppContext context;

        public CompanyService(TecAppContext context)
        {
            this.context = context;
        }


        public List<Company> GetAllCompanies()
        {
            return context.Set<Company>()
                .Include(c => c.Openings)
                .Include(c=>c.JobHistory_Company_Pairs)
                .ToList();
        }

        public Company GetCompanyFromId(int id)
        {
            return GetAllCompanies().FirstOrDefault(d => d.Id == id);
        }

        public Company AddCompany(Company company)
        {
            context.Companies.Add(company);
            context.SaveChanges();
            return company;
        }
    }
}
