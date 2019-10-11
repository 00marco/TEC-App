using System;
using System.Collections.Generic;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Services.EmployeeService;
using TEC_App.Services.OpeningsService;

namespace TEC_App.Tests
{
	public class CompanyOperationsTests
	{
        public CompanyOperationsTests()
        {
            TecAppContext = new TecAppContext();
            OpeningsService = new OpeningsService(TecAppContext);
        }
        public IOpeningsService OpeningsService { get; set; }

        public TecAppContext TecAppContext { get; set; }
        //	Let company create an opening
        //	view all openings

        [Test]
        public void GetOpeningsTest()
        {
            var openings = OpeningsService.GetOpenings();
            foreach (var v in openings)
            {
                Console.WriteLine();
                Console.WriteLine($"Company\t{v.Company.Name}");
                Console.WriteLine($"Date start]\t{v.DateTimeStart}");
                Console.WriteLine($"Date end\t{v.DateTimeEnd}");
                Console.WriteLine($"Hourly pay\t{v.HourlyPay}");
                Console.WriteLine($"Job name\t{v.Job.Name}");
                Console.WriteLine($"Job id\t{v.Job.Id}");
                Console.WriteLine($"Qualifications\t{v.RequiredQualification.Code}");
                Console.WriteLine();
            }

        }

        [Test]
        public void GetOpeningViewDtosTest()
        {
            var openings = OpeningsService.GetOpeningViewDTOList();
            foreach (var v in openings)
            {
                Console.WriteLine();
                Console.WriteLine($"Opening Number\t{v.CompanyWithOpeningDetailsDto.OpeningName}");
                Console.WriteLine($"Company Name\t{v.CompanyWithOpeningDetailsDto.CompanyName}");
                Console.WriteLine($"Required Quals\t{v.CompanyWithOpeningDetailsDto.RequiredQualifications}");
                Console.WriteLine($"Start Date\t{v.CompanyWithOpeningDetailsDto.StartDate}");
                Console.WriteLine($"End Date\t{v.CompanyWithOpeningDetailsDto.EndDate}");
                Console.WriteLine($"Hourly pay\t{v.CompanyWithOpeningDetailsDto.HourlyPay}");
                Console.WriteLine();
            }

        }

        //	remove opening 
        //	view all qualified candidates for the opening
        //	select which candidate will take the opening

    }
}