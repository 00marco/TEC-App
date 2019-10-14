using System.Windows.Input;
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
        private JobHistory _selectedJobHistory;
        private Candidate_Qualification _selectedCandidateQualification;
        private Candidate_Session _selectedCandidateSession;
        private Address_Candidate _selectedAddressCandidate;

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

        public Address_Candidate SelectedAddressCandidate
        {
            get => _selectedAddressCandidate;
            set => _selectedAddressCandidate = value;
        }

        public Candidate_Session SelectedCandidateSession
        {
            get => _selectedCandidateSession;
            set => _selectedCandidateSession = value;
        }

        public Candidate_Qualification SelectedCandidateQualification
        {
            get => _selectedCandidateQualification;
            set => _selectedCandidateQualification = value;
        }

        public JobHistory SelectedJobHistory
        {
            get => _selectedJobHistory;
            set => _selectedJobHistory = value;
        }


        public ICommand BackCommand => new RelayCommand(BackProc);

		private void BackProc()
		{
			Messenger.Default.Send(new NotificationMessage(nameof(CandidateView_ViewModel)));
		}
	}
}
