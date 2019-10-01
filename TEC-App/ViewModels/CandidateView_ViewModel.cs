using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Services;

namespace TEC_App.ViewModels
{
	public class CandidateViewDTO
	{
		public string CandidateName { get; set; }
		public string Qualifications { get; set; }
	}
    public class CandidateView_ViewModel : ViewModelBase
    {
	    public CandidateView_ViewModel()
	    {
		    
	    }

		public ObservableCollection<CandidateViewDTO> Candidates { get; set; } = new ObservableCollection<CandidateViewDTO>();
	    public ICommand GotoCandidateDetailsView => new RelayCommand(GotoCandidateDetailsProc);

	    private void GotoCandidateDetailsProc()
	    {
		    throw new NotImplementedException();
	    }

	    public ICommand TestChangeToOpeningsViewCommand => new RelayCommand(TestProc);

	    private void TestProc()
	    {
		    var message = new NotificationMessage(nameof(OpeningsView_ViewModel));
		    Messenger.Default.Send(message);
		}
    }
}
