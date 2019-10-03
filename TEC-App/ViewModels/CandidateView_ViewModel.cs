using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Models.DTO;
using TEC_App.Models.ViewDTO;
using TEC_App.Services;
using TEC_App.Services.EmployeeService;

namespace TEC_App.ViewModels
{
	public class CandidateView_ViewModel : ViewModelBase
    {
	    public CandidateView_ViewModel(IEmployeeService employeeService)
	    {
		    EmployeeService = employeeService;

		    Messenger.Default.Register<string>(this, s => NotifyMe(s));
		}

	    private void NotifyMe(string message)
	    {
		    if (message == "load")
		    {
			    LoadCandidateDetails();
		    }
	    }

	    public IEmployeeService EmployeeService { get; set; }
		public ObservableCollection<CandidateViewDTO> Candidates { get; set; } = new ObservableCollection<CandidateViewDTO>();
	    public ICommand GotoCandidateDetailsView => new RelayCommand(GotoCandidateDetailsProc);

	    private void GotoCandidateDetailsProc()
	    {
		    throw new NotImplementedException();
	    }

	    public void LoadCandidateDetails()
	    {
		    var candidates = EmployeeService.GetCandidateList();
		    var viewCandidates = new List<CandidateViewDTO>();
		    foreach (var v in candidates)
		    {
				viewCandidates.Add(new CandidateViewDTO()
				{
					CandidateWithQualificationsDto = v
				});
		    }

		    Candidates = new ObservableCollection<CandidateViewDTO>(viewCandidates);
	    }
	    public ICommand TestChangeToOpeningsViewCommand => new RelayCommand(TestProc);

	    private void TestProc()
	    {
		    var message = new NotificationMessage(nameof(OpeningsView_ViewModel));
		    Messenger.Default.Send(message);
		}
    }
}
