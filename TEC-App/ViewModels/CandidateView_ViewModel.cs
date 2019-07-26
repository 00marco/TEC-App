using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEC_App.ViewModels
{
	public class CandidateView_ViewModel : ViewModelBase
	{
		public CandidateView_ViewModel()
		{
			Text = "Candidate View";
		}
		public string Text { get; set; }
	}
}
