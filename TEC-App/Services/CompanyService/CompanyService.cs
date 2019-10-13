﻿using System.Collections.Generic;
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
    }
}
