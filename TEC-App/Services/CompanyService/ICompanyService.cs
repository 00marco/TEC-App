using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Views.CompaniesView;

namespace TEC_App.Services.CompanyService
{
    public interface ICompanyService
    {
        List<Company> GetAllCompanies();
        List<CompanyViewDTO> GetAllCompanyViewDtos();
        Company GetCompanyFromId(int id);
        Company AddCompany(Company company);
        void RemoveCompany(Company company);
        Company UpdateCompany(Company oldCompany, Company newCompany);

        void CreateOpening(Qualification qualification, Job job);
    }
}
