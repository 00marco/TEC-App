using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;

namespace TEC_App.Services.ZZZZZZZ_RemoveAllDatabaseEntriesAfterTesting
{
    public class EmptyDatabase
    {
        public AddressService.AddressService AddressService { get; set; }
        public EmployeeService.CandidateService CandidateService { get; set; }
        public QualificationsService.QualificationsService QualificationsService { get; set; }
        public CourseService.CourseService CourseService { get; set; }
        public CompanyService.CompanyService CompanyService { get; set; }
        public JobService.JobService JobService { get; set; }

        public EmptyDatabase()
        {
            var context = new TecAppContext();
            AddressService = new AddressService.AddressService(context);
            CandidateService = new EmployeeService.CandidateService(context);
            QualificationsService = new QualificationsService.QualificationsService(context);
            CourseService = new CourseService.CourseService(context);
            CompanyService = new CompanyService.CompanyService(context);
            JobService = new JobService.JobService(context);
        }
        [Test]
        public void RemoveTest()
        {
            
            foreach (var v in QualificationsService.GetAllQualifications())
            {
                QualificationsService.RemoveQualification(v);
            }

            foreach (var v in AddressService.GetAllAdresses())
            {
                AddressService.RemoveAddress(v);
            }

            foreach (var v in CandidateService.GetAllCandidates())
            {
                CandidateService.RemoveCandidate(v);
            }

            foreach (var v in CourseService.GetAllCourses())
            {
                CourseService.RemoveCourse(v);
            }

            foreach (var v in CompanyService.GetAllCompanies())
            {
                CompanyService.RemoveCompany(v);
            }

            foreach (var v in JobService.GetAllJobs())
            {
                JobService.RemoveJob(v);
            }
        }
    }
}
