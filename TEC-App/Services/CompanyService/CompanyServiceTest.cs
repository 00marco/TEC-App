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
                Console.WriteLine($"Id\t\t\t{v.Id}");
                Console.WriteLine($"Name\t\t\t{v.Name}");
                Console.WriteLine($"Job history\t\t{v.JobHistory_Company_Pairs.Count}");
                Console.WriteLine($"Number of openings\t{v.Openings.Count}");
                Console.WriteLine($"Last edit\t\t\t{v.Timestamp}");
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

        [Test]
        public void AddCompanyTest()
        {
            var random = new Random();
            var newCompany = new Company()
            {
                JobHistory_Company_Pairs = new List<JobHistory_Company>(),
                Name = $"Company-{random.Next()}",
                Openings = new List<Opening>(),
                Timestamp = DateTime.Now,
            };
            var company = CompanyService.AddCompany(newCompany);
        }
    }
}
