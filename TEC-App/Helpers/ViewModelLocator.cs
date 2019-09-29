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
		public ViewModelLocator()
		{
			MainViewModel = new MainViewModel();
			CandidateViewViewModel = new CandidateView_ViewModel();
			CompaniesViewViewModel = new CompaniesView_ViewModel();
			CourseViewViewModel = new CourseView_ViewModel();
			OpeningsViewViewModel = new OpeningsView_ViewModel();
			PlacementsViewViewModel = new PlacementsView_ViewModel();
		}
		public MainViewModel MainViewModel { get; set; }
		public CandidateView_ViewModel CandidateViewViewModel { get; set; }
		public CompaniesView_ViewModel CompaniesViewViewModel { get; set; }
		public CourseView_ViewModel CourseViewViewModel { get; set; }
		public OpeningsView_ViewModel OpeningsViewViewModel { get; set; }
		public PlacementsView_ViewModel PlacementsViewViewModel { get; set; }
	}
}
