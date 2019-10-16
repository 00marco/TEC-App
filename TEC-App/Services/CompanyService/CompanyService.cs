using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Services.CompanyService.QueryObjects;
using TEC_App.Views.CompaniesView;

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
                .ThenInclude(d=>d.Job)
                .Include(c=>c.JobHistory_Company_Pairs)
                .ThenInclude(d=>d.JobHistory)
                .ToList();
        }

        public List<CompanyViewDTO> GetAllCompanyViewDtos()
        {
            return context.Set<Company>()
                .Include(c => c.Openings)
                .Include(c => c.JobHistory_Company_Pairs)
                .MapCompanyToDto()
                .ToList();
        }

        public Company GetCompanyFromId(int id)
        {
            var company = GetAllCompanies().FirstOrDefault(d => d.Id == id);
            if (company == null)
            {
                return new Company()
                {
                    Id = -1
                };
            }

            return company;
        }

        public Company AddCompany(Company company)
        {
            context.Companies.Add(company);
            context.SaveChanges();
            return company;
        }

        public void RemoveCompany(Company company)
        {
            context.Remove(context.Companies.Single(d => d.Id == company.Id));
            context.SaveChanges();
        }

        public Company UpdateCompany(Company oldCompany, Company newCompany)
        {
            var company = context.Companies.Find(oldCompany.Id);
            company.Name = newCompany.Name;
            context.SaveChanges();
            return company;
        }

        public void CreateOpening(Qualification qualification, Job job)
        {
        }
    }
}
