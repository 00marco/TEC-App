using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Models.ViewDTO;
using TEC_App.Services.EmployeeService;
using TEC_App.Services.OpeningsService;
using TEC_App.ViewModels;
using TEC_App.Views.OpeningsView;

namespace TEC_App.Views.CandidatesQualifiedForOpeningView
{
    public class CandidateQualifiedForOpeningViewModel : ViewModelBase
    {
        public CandidateQualifiedForOpeningViewModel(ICandidateService candidateService, IOpeningsService openingService)
        {
            CandidateService = candidateService;
            OpeningsService = openingService;
            Messenger.Default.Register<ViewQualifiedCandidatesForOpeningViewMessage>(this, LoadCandidatesQualifiedForOpening);
        }

        public ObservableCollection<Candidate> Candidates { get; set; } = new ObservableCollection<Candidate>();
        public Candidate SelectedCandidate { get; set; }
        public ICandidateService CandidateService { get; set; }
        public IOpeningsService OpeningsService { get; set; }
        private void LoadCandidatesQualifiedForOpening(ViewQualifiedCandidatesForOpeningViewMessage obj)
        {
            var candidates = CandidateService.GetCandidatesQualifiedForRequiredQualification(obj.RequiredQualificationId);
            Candidates.Clear();
            foreach (var v in candidates)
            {
                Candidates.Add(v);
            }
            //TODO might want to use DTO instead of full candidate soon
        }



        public ICommand HireCandidateCommand => new RelayCommand(HireCandidate);
        public void HireCandidate()
        {
            throw new NotImplementedException();
        }

        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
	        Messenger.Default.Send(new NotificationMessage(nameof(OpeningsView_ViewModel)));
        }
	}
}
