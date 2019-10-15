using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Services.EmployeeService;
using TEC_App.ViewModels;
using TEC_App.Views.AddCandidateView;
using TEC_App.Views.IndividualCandidateDetailsView;

namespace TEC_App.Views.CandidateView
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
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(nameof(IndividualCandidateDetailsView_ViewModel)));

        }

        public void LoadCandidateDetails()
	    {
            var candidates = CandidateService.GetAllCandidateViewDtos();
            Candidates.Clear();
            foreach (var v in candidates)
            {
                Candidates.Add(v);
            }

        }
	  

        public ICommand AddCandidateCommand => new RelayCommand(AddCandidate);

        private void AddCandidate()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(nameof(AddCandidateViewModel)));
            Messenger.Default.Send<LoadAddCandidateViewMessage>(new LoadAddCandidateViewMessage());
        }
    }
}
