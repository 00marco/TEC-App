﻿using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Services.EmployeeService;
using TEC_App.ViewModels;
using TEC_App.Views.CandidateView;

namespace TEC_App.Views.IndividualCandidateDetailsView
{
    public class IndividualCandidateDetailsView_ViewModel : ViewModelBase
    {
        public IndividualCandidateDetailsView_ViewModel(ICandidateService candidateService)
        {
            CandidateService = candidateService;
			Messenger.Default.Register<ViewCandidateDetailsMessage>(this, NotifyMe);

        }

        private void NotifyMe(ViewCandidateDetailsMessage obj)
        {
            GetCandidateFromId(obj.CandidateId);
        }

        private void GetCandidateFromId(int objCandidateId)
        {
            Candidate = CandidateService.GetCandidateFromId(objCandidateId);
        }

        public Candidate Candidate { get; set; }
        public ICandidateService CandidateService { get; set; }

		public ICommand BackCommand => new RelayCommand(BackProc);

		private void BackProc()
		{
			Messenger.Default.Send(new NotificationMessage(nameof(CandidateView_ViewModel)));
		}
	}
}