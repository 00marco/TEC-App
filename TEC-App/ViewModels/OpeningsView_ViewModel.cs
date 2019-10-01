using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace TEC_App.ViewModels
{
	public class CompanyOpeningDTO
	{
		public string CompanyName { get; set; }
		public string OpeningName { get; set; }
		public string RequiredQualifications { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public float HourlyPay { get; set; }
	}
    public class OpeningsView_ViewModel : ViewModelBase
    {
	    public ObservableCollection<CompanyOpeningDTO> CompanyOpeningDtos { get; set; } =
		    new ObservableCollection<CompanyOpeningDTO>();

		public ICommand GotoListOfQualifiedCandidatesForOpeningCommand => new RelayCommand(GotoListOfQualifiedCandidatesForOpeningProc);

		private void GotoListOfQualifiedCandidatesForOpeningProc()
		{
			throw new NotImplementedException();
		}
    }
}
