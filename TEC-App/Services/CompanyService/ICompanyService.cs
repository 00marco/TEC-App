using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;

namespace TEC_App.Services.CompanyService
{
    public interface ICompanyService
    {
        List<Company> GetAllCompanies();
        Company GetCompanyFromId(int id);

    }
}
