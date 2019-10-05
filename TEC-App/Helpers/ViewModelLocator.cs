using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.ViewModels;

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
			IndividualCandidateDetailsViewViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<IndividualCandidateDetailsView_ViewModel>();
			AddCandidateViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<AddCandidateViewModel>();
			AddCompanyViewModel = CommonServiceLocator.ServiceLocator.Current.GetInstance<AddCompanyViewModel>();
			
		}
		public MainViewModel MainViewModel { get; set; }
		public IndividualCandidateDetailsView_ViewModel IndividualCandidateDetailsViewViewModel { get; set; }
		public CandidateView_ViewModel CandidateViewViewModel { get; set; }
		public CompaniesView_ViewModel CompaniesViewViewModel { get; set; }
		public AddCandidateViewModel AddCandidateViewModel { get; set; }
        public CourseView_ViewModel CourseViewViewModel { get; set; }
		public OpeningsView_ViewModel OpeningsViewViewModel { get; set; }
		public PlacementsView_ViewModel PlacementsViewViewModel { get; set; }
		public AddCompanyViewModel AddCompanyViewModel { get; set; }
    }
}
