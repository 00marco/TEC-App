using System;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Services.CompanyService;
using TEC_App.Services.OpeningsService;

namespace TEC_App.Tests
{
	public class CompanyManagement
	{
        public CompanyManagement()
        {
            TecAppContext = new TecAppContext();
            CompanyService = new CompanyService(TecAppContext);
        }
        public ICompanyService CompanyService { get; set; }

        public TecAppContext TecAppContext { get; set; }
        //	Add new company
        //	View all companies
        [Test]
        public void GetCompanies()
        {
            var companies = CompanyService.GetCompanies();
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
		//	Edit company details
		//	Remove company
		//	Let company create an OPENING

	}
}