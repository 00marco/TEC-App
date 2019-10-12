using System;
using System.Data.SqlTypes;
using GalaSoft.MvvmLight.Ioc;
using TEC_App.Models.Db;
using TEC_App.Services;
using TEC_App.Services.CompanyService;
using TEC_App.Services.CourseService;
using TEC_App.Services.EmployeeService;
using TEC_App.Services.JobService;
using TEC_App.Services.OpeningsService;
using TEC_App.Services.PlacementsService;
using TEC_App.Services.QualificationsService;
using TEC_App.ViewModels;
using TEC_App.Views.AddCandidateView;
using TEC_App.Views.AddCompanyView;
using TEC_App.Views.AddCourseView;
using TEC_App.Views.AddOpeningView;
using TEC_App.Views.CandidatesQualifiedForOpeningView;
using TEC_App.Views.CandidateView;
using TEC_App.Views.CompaniesView;
using TEC_App.Views.CourseView;
using TEC_App.Views.IndividualCandidateDetailsView;
using TEC_App.Views.OpeningsView;
using TEC_App.Views.PlacementsView;

namespace TEC_App.Helpers
{
	public class InitializeIoc
	{
		private bool isTestMode = false;
		public InitializeIoc()
		{
			CommonServiceLocator.ServiceLocator.SetLocatorProvider(()=>SimpleIoc.Default);
            SimpleIoc.Default.Register<TecAppContext>();

            if (isTestMode)
			{
				RegisterTestServices();
			}
			else
			{
				RegisterServices();
			}

			RegisterViewModels();
		}

		private void RegisterViewModels()
		{
			SimpleIoc.Default.Register<CandidateView_ViewModel>();
			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<IndividualCandidateDetailsView_ViewModel>();
			SimpleIoc.Default.Register<CompaniesView_ViewModel>();
			SimpleIoc.Default.Register<CourseView_ViewModel>();
			SimpleIoc.Default.Register<OpeningsView_ViewModel>();
			SimpleIoc.Default.Register<PlacementsView_ViewModel>();
			SimpleIoc.Default.Register<AddCandidateViewModel>();
			SimpleIoc.Default.Register<AddCompanyViewModel>();
			SimpleIoc.Default.Register<AddCourseViewModel>();
			SimpleIoc.Default.Register<AddOpeningViewModel>();
			SimpleIoc.Default.Register<CandidateQualifiedForOpeningViewModel>();
        }

		private void RegisterServices()
		{
			SimpleIoc.Default.Register<ICompanyService, CompanyService>();
			SimpleIoc.Default.Register<ICourseService, CourseService>();
			SimpleIoc.Default.Register<ICandidateService, CandidateService>();
			SimpleIoc.Default.Register<IPlacementService, PlacementService>(); 
			SimpleIoc.Default.Register<IOpeningsService, OpeningsService>();
			SimpleIoc.Default.Register<IQualificationsService, QualificationsService>();
			SimpleIoc.Default.Register<IJobService, JobService>();
        }

		private void RegisterTestServices()
		{
			SimpleIoc.Default.Register<ICompanyService, MockCompanyService>();
			SimpleIoc.Default.Register<IPlacementService, PlacementService>(); //no test service for PlacementService
            SimpleIoc.Default.Register<ICourseService, MockCourseService>();
			SimpleIoc.Default.Register<ICandidateService, MockCandidateService>();
			SimpleIoc.Default.Register<IQualificationsService, QualificationsService>(); // no test service for QualificationsService
			SimpleIoc.Default.Register<IJobService, JobService>(); // no test service for job service
			SimpleIoc.Default.Register<IOpeningsService, MockOpeningsService>();

        }
	}
}