using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using TEC_App.Models.DTO;

namespace TEC_App.ViewModels
{
	public class OpeningsView_ViewModel : ViewModelBase
    {
	    public ObservableCollection<CompanyWithOpeningDetailsDTO> CompanyOpeningDtos { get; set; } =
		    new ObservableCollection<CompanyWithOpeningDetailsDTO>();

		public ICommand GotoListOfQualifiedCandidatesForOpeningCommand => new RelayCommand(GotoListOfQualifiedCandidatesForOpeningProc);

		private void GotoListOfQualifiedCandidatesForOpeningProc()
		{
			throw new NotImplementedException();
		}
    }
}
