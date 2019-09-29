using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Services;

namespace TEC_App.ViewModels
{
    public class CandidateView_ViewModel : ViewModelBase
    {
	    public CandidateView_ViewModel()
	    {
		    
	    }

	    public ICommand TestChangeToOpeningsViewCommand => new RelayCommand(TestProc);

	    private void TestProc()
	    {
		    var message = new NotificationMessage("Opening");
		    Messenger.Default.Send(message);
		}
    }
}
