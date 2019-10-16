using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Models.DTO;
using TEC_App.Services.EmployeeService;
using TEC_App.Services.JobHistoryCompanyService;
using TEC_App.Services.JobHistoryJobService;
using TEC_App.Services.JobHistoryService;
using TEC_App.Services.OpeningsService;
using TEC_App.Services.PlacementService;
using TEC_App.ViewModels;
using TEC_App.Views.OpeningsView;

namespace TEC_App.Views.CandidatesQualifiedForOpeningView
{
    public class CandidateQualifiedForOpeningViewModel : ViewModelBase
    {
        public CandidateQualifiedForOpeningViewModel(ICandidateService candidateService, IOpeningsService openingService, IPlacementService placementService, IJobHistoryService jobHistoryService, IJobHistoryCompanyService jobHistoryCompanyService, IJobHistoryJobService jobHistoryJobService)
        {
            CandidateService = candidateService;
            OpeningsService = openingService;
            PlacementService = placementService;
            JobHistoryService = jobHistoryService;
            JobHistoryCompanyService = jobHistoryCompanyService;
            JobHistoryJobService = jobHistoryJobService;
            Messenger.Default.Register<ViewQualifiedCandidatesForOpeningViewMessage>(this, LoadCandidatesQualifiedForOpening);
        }

        public ObservableCollection<Candidate> Candidates { get; set; } = new ObservableCollection<Candidate>();
        public Candidate SelectedCandidate { get; set; }
        public Opening Opening { get; set; }
        public ICandidateService CandidateService { get; set; }
        public IOpeningsService OpeningsService { get; set; }
        public IPlacementService PlacementService { get; set; }
        public IJobHistoryService JobHistoryService { get; set; }
        public IJobHistoryCompanyService JobHistoryCompanyService { get; set; }
        public IJobHistoryJobService JobHistoryJobService { get; set; }


        private void LoadCandidatesQualifiedForOpening(ViewQualifiedCandidatesForOpeningViewMessage obj)
        {
            var placements = PlacementService.GetAllPlacements().Where(d => d.OpeningId == obj.Opening.Id);
            Opening = obj.Opening;
            var candidates = CandidateService.GetCandidatesQualifiedForRequiredQualification(obj.RequiredQualificationId);
            Candidates.Clear();
            foreach (var v in candidates)
            {
                if (placements.Any(d => d.CandidateId == v.Id && d.OpeningId == Opening.Id))
                {
                    continue;
                }
                Candidates.Add(v);
            }
            //TODO might want to use DTO instead of full candidate soon
        }



        public ICommand HireCandidateCommand => new RelayCommand(HireCandidate);
        public void HireCandidate()
        {
            if (SelectedCandidate == null)
            {
                MessageBox.Show("Please select a candidate");
                return;
            }
            if (MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var placement = PlacementService.AddPlacementToCandidate(new Placement()
                {
                    Candidate = SelectedCandidate,
                    Opening = Opening,
                    Timestamp = DateTime.Now,
                    TotalHoursWorked = 0
                    //TODO UPdate function to increase total hours worked
                });
                var jobHistory = JobHistoryService.AddJobHistory(new JobHistory()
                {
                    Candidate = SelectedCandidate,
                    DateTimeStart = DateTime.Now,

                });
                var jobHistoryCompany = JobHistoryCompanyService.Add(new JobHistory_Company()
                {
                    JobHistory = jobHistory,
                    Company = Opening.Company
                });
                var jobHistoryJob = JobHistoryJobService.Add(new JobHistory_Job()
                {
                    JobHistory = jobHistory,
                    Job = Opening.Job
                });

                if (MessageBox.Show("Close opening?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    OpeningsService.CloseOpening(Opening);
                }
                BackProc();

                //TODO opening does not disappear after candidate is hired
            }

        }

        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
	        Messenger.Default.Send(new NotificationMessage(nameof(OpeningsView_ViewModel)));
            Messenger.Default.Send(new LoadOpeningsViewMessage());
        }
	}
}
