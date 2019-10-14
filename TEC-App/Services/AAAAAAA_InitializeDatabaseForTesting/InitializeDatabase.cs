using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models.Db;
using TEC_App.Views.AddCourseView;

namespace TEC_App.Services.AAAAAAA_InitializeDatabaseForTesting
{
    public class InitializeDatabase
    {
        private Random random = new Random();
        public AddressService.AddressService AddressService { get; set; }
        public EmployeeService.CandidateService CandidateService { get; set; }
        public QualificationsService.QualificationsService QualificationsService { get; set; }
        public CourseService.CourseService CourseService { get; set; }
        public CompanyService.CompanyService CompanyService { get; set; }
        public JobService.JobService JobService { get; set; }
        public SessionService.SessionService SessionService { get; set; }
        public LocationService.LocationService LocationService { get; set; }
        public SessionLocationService.SessionLocationService SessionLocationService { get; set; }


        public InitializeDatabase()
        {
            var context = new TecAppContext();
            AddressService = new AddressService.AddressService(context);
            CandidateService = new EmployeeService.CandidateService(context);
            QualificationsService = new QualificationsService.QualificationsService(context);
            CourseService = new CourseService.CourseService(context);
            CompanyService = new CompanyService.CompanyService(context);
            JobService = new JobService.JobService(context);
            SessionService = new SessionService.SessionService(context);
            LocationService = new LocationService.LocationService(context);

            SessionLocationService = new SessionLocationService.SessionLocationService(context);
        }

        [Test]
        public void AddTest()
        {
            AddQualification();
            for (int x = 0; x < 200; x++)
            {
                AddAddress();
                AddCandidate();
                AddCourse();
                AddCompany();
                AddJob();
            }
            for (int x = 0; x < 200; x++)
            {
                AddLocation();
            }

            

        }

        private void AddLocation()
        {
            var random = new Random();
            var randomAddress = AddressService.GetAllAdresses()[random.Next(100)];
            LocationService.AddLocation(new Location()
            {
                Address = randomAddress,

            });
        }

        private void AddSession()
        {
            var randomCourse = CourseService.GetAllCourses()[random.Next(100)];
            var randomLocation = LocationService.GetAllLocations()[random.Next(100)];
            var addedSession = new Session()
            {
                Course = randomCourse
            };
        }

        private void AddJob()
        {
            JobService.AddJob(new Job()
            {
                Name = $"Name-{random.Next()}",
                
            });
        }

        private void AddCompany()
        {
            CompanyService.AddCompany(new Company()
            {
                Name = $"Name-{random.Next()}",
                Timestamp = DateTime.Now,

            });
        }

        private void AddCourse()
        {
            CourseService.AddCourse(new Course()
            {
                Name = $"Name-{random.Next()}"

            });
        }

        private void AddQualification()
        {
            QualificationsService.AddQualification(new Qualification()
            {
                Code = "SEC-45",
                Description = "Secretarial work, at least 45 words per minute",
            });
            QualificationsService.AddQualification(new Qualification()
            {
                Code = "SEC-60",
                Description = "Secretarial work, at least 60 words per minute",
            });
            QualificationsService.AddQualification(new Qualification()
            {
                Code = "Clerk",
                Description = "General Clerking work",
            });
            QualificationsService.AddQualification(new Qualification()
            {
                Code = "PRG-VB",
                Description = "Programmer, Visual Basic",
            });
            QualificationsService.AddQualification(new Qualification()
            {
                Code = "PRG-C++",
                Description = "Programmer, C++",
            });
            QualificationsService.AddQualification(new Qualification()
            {
                Code = "DBA-ORA",
                Description = "Database Administrator, Oracle",
            });
            QualificationsService.AddQualification(new Qualification()
            {
                Code = "DBA-DB2",
                Description = "Database Administrator, IBMDB2",
            });
            QualificationsService.AddQualification(new Qualification()
            {
                Code = "DBA-DB2",
                Description = "Database Administrator, MS SQL Server",
            });
            QualificationsService.AddQualification(new Qualification()
            {
                Code = "SYS-1",
                Description = "Systems Analyst, level 1",
            });
            QualificationsService.AddQualification(new Qualification()
            {
                Code = "SYS-2",
                Description = "Systems Analyst, level 2",
            });
            QualificationsService.AddQualification(new Qualification()
            {
                Code = "NW-NOV",
                Description = "Network Administrator, Novell experience",
            });
            QualificationsService.AddQualification(new Qualification()
            {
                Code = "WD-CF",
                Description = "Web Developer, ColdFusion",
            });

        }

        private void AddCandidate()
        {
            CandidateService.AddCandidate(new Candidate()
            {
                FirstName = $"{random.Next()}",
                MiddleName = "Middle",
                LastName = "Last",
                Timestamp = DateTime.Now,

            });
        }

        private void AddAddress()
        {
            AddressService.AddAddress(new Address()
            {
                ZipCode = $"{random.Next()}",
                City = "City",
                Province = "Province",
                Street = "Street"
            });
        }
    }
}
