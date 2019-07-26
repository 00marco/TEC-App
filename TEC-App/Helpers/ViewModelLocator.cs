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
			JobOpeningsViewModel = new JobOpenings_ViewModel();
		}
		public MainViewModel MainViewModel { get; set; }
		public CandidateView_ViewModel CandidateViewViewModel { get; set; }
		public JobOpenings_ViewModel JobOpeningsViewModel { get; set; }
	}
}
