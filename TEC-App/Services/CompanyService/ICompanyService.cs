using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;

namespace TEC_App.Services.CompanyService
{
    public interface ICompanyService
    {
        List<Company> GetAllCompanies();
        List<CompanyViewDTO> GetAllCompanyViewDtos();
        Company GetCompanyFromId(int id);
        Company AddCompany(Company company);
        void RemoveCompany(Company company);

    }
}
