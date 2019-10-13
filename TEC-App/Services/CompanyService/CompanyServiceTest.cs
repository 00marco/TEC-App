using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;

namespace TEC_App.Services.CompanyService
{
    public class CompanyServiceTest
    {
        public TecAppContext TecAppContext { get; set; }
        public ICompanyService CompanyService { get; set; }

        public CompanyServiceTest()
        {
            TecAppContext = new TecAppContext();
            CompanyService = new CompanyService(TecAppContext);
        }
        [Test]
        public void GetCompanies()
        {
            var companies = CompanyService.GetAllCompanies();
            foreach (var v in companies)
            {
                Console.WriteLine();
                Console.WriteLine($"Id\t{v.Id}");
                Console.WriteLine($"Name\t{v.Name}");
                Console.WriteLine($"Job history\t{v.JobHistory_Company_Pairs.Count}");
                Console.WriteLine($"Number of openings\t{v.Openings.Count}");
                Console.WriteLine($"Last edit\t{v.Timestamp}");
                Console.WriteLine();
            }
        }

        [TestCase(1, "Skinix")]
        [TestCase(2, "Demizz")]
        [TestCase(3, "Snaptags")]
        [TestCase(4, "Yodo")]
        public void GetCompanyFromIdTest(int id, string result)
        {
            var company = CompanyService.GetCompanyFromId(id);
            Assert.AreEqual(company.Name, result);
        }

    }
}
