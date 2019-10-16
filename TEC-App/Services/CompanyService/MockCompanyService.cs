using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Views.CompaniesView;

namespace TEC_App.Services.CompanyService
{
    public class MockCompanyService : ICompanyService
    {
        public List<Company> GetAllCompanies()
        {
            throw new System.NotImplementedException();
        }

        public List<CompanyViewDTO> GetAllCompanyViewDtos()
        {
            throw new System.NotImplementedException();
        }

        public Company GetCompanyFromId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Company AddCompany(Company company)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCompany(Company company)
        {
            throw new System.NotImplementedException();
        }

        public Company UpdateCompany(Company oldCompany, Company newCompany)
        {
            throw new System.NotImplementedException();
        }

        public void CreateOpening(Qualification qualification, Job job)
        {
            throw new System.NotImplementedException();
        }

        public List<CompanyViewDTO> GetCompanyViewDtos()
        {
            throw new System.NotImplementedException();
        }
    }
}
