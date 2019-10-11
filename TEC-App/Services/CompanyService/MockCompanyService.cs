using System.Collections.Generic;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;

namespace TEC_App.Services.CompanyService
{
    public class MockCompanyService : ICompanyService
    {
        public List<Company> GetCompanies()
        {
            throw new System.NotImplementedException();
        }

        public List<CompanyViewDTO> GetCompanyViewDtos()
        {
            throw new System.NotImplementedException();
        }
    }
}
