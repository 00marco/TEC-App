using System;
using System.Collections.Generic;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Services.EmployeeService;
using TEC_App.Services.OpeningsService;
using TEC_App.Services.PlacementsService;

namespace TEC_App.Tests
{
	public class CompanyOperationsTests
	{
        public CompanyOperationsTests()
        {
            TecAppContext = new TecAppContext();
            OpeningsService = new OpeningsService(TecAppContext);
            PlacementService = new PlacementService(TecAppContext);
        }
        public IOpeningsService OpeningsService { get; set; }
        public IPlacementService PlacementService { get; set; }

        public TecAppContext TecAppContext { get; set; }
        //	Let company create an opening
        //	view all openings


        [Test]
        public void GetPlacementsTest()
        {
            var placements = PlacementService.GetPlacement();
            foreach (var v in placements)
            {
                Console.WriteLine();
                Console.WriteLine($"Placement id\t\t{v.Id}");
                Console.WriteLine($"Timestamp \t\t{v.Timestamp}");
                Console.WriteLine($"Total hours worked \t{v.TotalHoursWorked}");
                Console.WriteLine($"Opening id\t\t{v.Opening.Id}");
                Console.WriteLine($"Candidate name\t\t'{v.Candidate.FullName}");
                Console.WriteLine();
            }
        }
        [Test]
        public void GetPlacementsWithCandidateDtosTest()
        {
            var placements = PlacementService.GetPlacementWithCandidateDtos();
            foreach (var v in placements)
            {
                Console.WriteLine();
                Console.WriteLine($"Candidate \t{v.CandidateName}");
                Console.WriteLine($"Company\t{v.CompanyName}");
                Console.WriteLine($"Start \t\t{v.DateTimeStart}");
                Console.WriteLine($"End\t\t{v.DateTimeEnd}");
                Console.WriteLine($"Hours worked\t{v.HoursWorked}");
                Console.WriteLine($"Payment\t\t{v.Payment}");
                Console.WriteLine();
            }
        }
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