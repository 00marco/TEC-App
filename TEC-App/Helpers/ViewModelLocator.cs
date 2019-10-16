using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.ViewModels;
using TEC_App.Views.AddCandidateView;
using TEC_App.Views.AddCompanyView;
using TEC_App.Views.AddCourseView;
using TEC_App.Views.AddOpeningView;
using TEC_App.Views.AddSessionView;
using TEC_App.Views.CandidatesQualifiedForOpeningView;
using TEC_App.Views.CandidateView;
using TEC_App.Views.CompaniesView;
using TEC_App.Views.CompanyDetailsView;
using TEC_App.Views.CourseView;
using TEC_App.Views.IndividualCandidateDetailsView;
using TEC_App.Views.OpeningsView;
using TEC_App.Views.PlacementsView;
using TEC_App.Views.SessionAttendanceView;
using TEC_App.Views.SessionsView;
using TEC_App.Views.UpdateCandidateView;
using TEC_App.Views.UpdateCompanyDetailsView;

namespace TEC_App.Helpers
{
	public class ViewModelLocator
	{
		private readonly InitializeIoc initializeIoc;
		public ViewModelLocator()
		{
			initializeIoc = new InitializeIoc();
            MainViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<MainViewModel>();
			CandidateViewViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<CandidateView_ViewModel>();
			CompaniesViewViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<CompaniesView_ViewModel>();
			CourseViewViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<CourseView_ViewModel>();
			OpeningsViewViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<OpeningsView_ViewModel>();
			PlacementsViewViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<PlacementsView_ViewModel>();
            IndividualCandidateDetailsViewViewModel = CommonServiceLocator.ServiceLocator.Current
                .GetInstance<IndividualCandidateDetailsView_ViewModel>();
			AddCandidateViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<AddCandidateViewModel>();
			AddCompanyViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<AddCompanyViewModel>();
            AddCourseViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<AddCourseViewModel>();
            AddOpeningViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<AddOpeningViewModel>();
            CandidateQualifiedForOpeningViewModel = CommonServiceLocator.ServiceLocator.Current
                .GetInstance<CandidateQualifiedForOpeningViewModel>();
            SessionsViewViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<SessionsView_ViewModel>();
            AddSession_ViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<AddSession_ViewModel>();
            SessionAttendanceView_ViewModel =
                CommonServiceLocator.ServiceLocator.Current.GetInstance<SessionAttendanceView_ViewModel>();
            UpdateCandidateviewViewModel =
                CommonServiceLocator.ServiceLocator.Current.GetInstance<UpdateCandidateview_ViewModel>();
            CompanyDetailsViewViewModel =
                CommonServiceLocator.ServiceLocator.Current.GetInstance<CompanyDetailsView_ViewModel>();
            UpdateCompanyDetailsViewViewModel = CommonServiceLocator.ServiceLocator.Current
                .GetInstance<UpdateCompanyDetailsView_ViewModel>();

        }
		public MainViewModel MainViewModel { get; set; }
		public IndividualCandidateDetailsView_ViewModel IndividualCandidateDetailsViewViewModel { get; set; }
		public CandidateView_ViewModel CandidateViewViewModel { get; set; }
		public CompaniesView_ViewModel CompaniesViewViewModel { get; set; }
		public CompanyDetailsView_ViewModel CompanyDetailsViewViewModel { get; set; }
        public AddCandidateViewModel AddCandidateViewModel { get; set; }
        public CourseView_ViewModel CourseViewViewModel { get; set; }
		public OpeningsView_ViewModel OpeningsViewViewModel { get; set; }
		public PlacementsView_ViewModel PlacementsViewViewModel { get; set; }
		public AddCompanyViewModel AddCompanyViewModel { get; set; }
		public AddCourseViewModel AddCourseViewModel { get; set; }
		public AddOpeningViewModel AddOpeningViewModel { get; set; }
		public CandidateQualifiedForOpeningViewModel CandidateQualifiedForOpeningViewModel { get; set; }
		public SessionsView_ViewModel SessionsViewViewModel { get; set; }
		public AddSession_ViewModel AddSession_ViewModel { get; set; }
		public SessionAttendanceView_ViewModel SessionAttendanceView_ViewModel { get; set; }
        public UpdateCandidateview_ViewModel UpdateCandidateviewViewModel { get; set; }
        public UpdateCompanyDetailsView_ViewModel UpdateCompanyDetailsViewViewModel { get; set; }
    }
}
