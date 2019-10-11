using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.DTO;
using TEC_App.Models.ViewDTO;
using TEC_App.Services;
using TEC_App.Services.EmployeeService;

namespace TEC_App.ViewModels
{
	public class CandidateView_ViewModel : ViewModelBase
    {
	    public CandidateView_ViewModel(ICandidateService candidateService)
	    {
		    CandidateService = candidateService;

		    Messenger.Default.Register<LoadCandidateViewMessage>(this, s => NotifyMe(s));
		}

	    private void NotifyMe(LoadCandidateViewMessage message)
	    {
		    
            LoadCandidateDetails();
		    
	    }

	    public ICandidateService CandidateService { get; set; }
		public ObservableCollection<CandidateViewDTO> Candidates { get; set; } = new ObservableCollection<CandidateViewDTO>();
	    public ICommand GotoCandidateDetailsView => new RelayCommand(GotoCandidateDetailsProc);

	    private void GotoCandidateDetailsProc()
	    {
		    throw new NotImplementedException();
	    }

	    public void LoadCandidateDetails()
	    {
		    var candidates = CandidateService.GetCandidateWithQualificationsDtoList();
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
	  

        public ICommand AddCandidateCommand => new RelayCommand(AddCandidate);

        private void AddCandidate()
        {

            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(nameof(AddCandidateViewModel)));
        }
    }
}
