using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;

namespace TEC_App.Services.CompanyService
{
    public class MockCompanyService : ICompanyService
    {
        public List<Company> GetAllCompanies()
        {
            throw new System.NotImplementedException();
        }

        public Company GetCompanyFromId(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<CompanyViewDTO> GetCompanyViewDtos()
        {
            throw new System.NotImplementedException();
        }
    }
}
