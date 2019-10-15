using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Services.QualificationDevelopedByCourseService;

namespace TEC_App.Services.ZZZZZZZ_RemoveAllDatabaseEntriesAfterTesting
{
    public class EmptyDatabase
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
        public OpeningsService.OpeningsService OpeningService { get; set; }
        public PlacementService.PlacementService PlacementService { get; set; }
        public JobHistoryJobService.JobHistoryJobService JobHistoryJobService { get; set; }
        public JobHistoryService.JobHistoryService JobHistoryService { get; set; }
        public AddressCandidateService.AddressCandidateService AddressCandidateService { get; set; }
        public CandidateQualificationService.CandidateQualificationService CandidateQualificationService { get; set; }
        public JobHistoryCompanyService.JobHistoryCompanyService JobHistoryCompanyService { get; set; }
        public PrerequisitesForCourseService.PrerequisitesForCourseService PrerequisitesForCourseService { get; set; }
        public QualificationDevelopedByCourseService.QualificationDevelopedByCourseService QualificationDevelopedByCourseService { get; set; }


        public EmptyDatabase()
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
            OpeningService = new OpeningsService.OpeningsService(context);
            PlacementService = new PlacementService.PlacementService(context);
            JobHistoryService = new JobHistoryService.JobHistoryService(context);

            JobHistoryCompanyService = new JobHistoryCompanyService.JobHistoryCompanyService(context);
            SessionLocationService = new SessionLocationService.SessionLocationService(context);
            JobHistoryJobService = new JobHistoryJobService.JobHistoryJobService(context);
            AddressCandidateService = new AddressCandidateService.AddressCandidateService(context);
            CandidateQualificationService = new CandidateQualificationService.CandidateQualificationService(context);
            PrerequisitesForCourseService = new PrerequisitesForCourseService.PrerequisitesForCourseService(context);
            QualificationDevelopedByCourseService =
                new QualificationDevelopedByCourseService.QualificationDevelopedByCourseService(context);

        }
        //[Test]
        public void RemoveTest()
        {
            
            foreach (var v in QualificationsService.GetAllQualifications())
            {
                QualificationsService.RemoveQualification(v);
            }

            foreach (var v in AddressCandidateService.GetAllAddressCandidatePairs())
            {
                AddressCandidateService.Remove(v);
            }

            foreach (var v in AddressService.GetAllAdresses())
            {
                AddressService.RemoveAddress(v);
            }

            foreach (var v in CandidateQualificationService.GetAll())
            {
                CandidateQualificationService.RemoveQualificationFromCandidate(v.CandidateId, v.QualificationId);
            }

            foreach (var v in CandidateService.GetAllCandidates())
            {
                CandidateService.RemoveCandidate(v);
            }

            foreach (var v in CompanyService.GetAllCompanies())
            {
                CompanyService.RemoveCompany(v);
            }

            foreach (var v in CourseService.GetAllCourses())
            {
                CourseService.RemoveCourse(v);
            }

            foreach (var v in JobHistoryCompanyService.GetAll())
            {
                JobHistoryCompanyService.Remove(v.JobHistoryId, v.CompanyId);
            }

            foreach (var v in JobHistoryJobService.GetAll())
            {
                JobHistoryJobService.Remove(v.JobHistoryId, v.JobId);
            }

            foreach (var v in JobHistoryService.GetAllJobHistories())
            {
                JobHistoryService.RemoveJobHistory(v);
            }

            foreach (var v in JobService.GetAllJobs())
            {
                JobService.RemoveJob(v);
            }

            foreach (var v in LocationService.GetAllLocations())
            {
                LocationService.RemoveLocation(v);
            }

            foreach (var v in OpeningService.GetAllOpenings())
            {
                OpeningService.RemoveOpening(v);
            }

            foreach (var v in PlacementService.GetAllPlacements())
            {
                PlacementService.RemovePlacement(v);
            }

            foreach (var v in PrerequisitesForCourseService.GetAll())
            {
                PrerequisitesForCourseService.Remove(v.CourseId, v.QualificationId);
            }

            foreach (var v in QualificationDevelopedByCourseService.GetAll())
            {
                QualificationDevelopedByCourseService.Remove(v.CourseId, v.QualificationId);
            }
        }
    }
}
