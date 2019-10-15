using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.DTO;

namespace TEC_App.Views.CandidatesQualifiedForOpeningView
{
    public class CandidatesQualifiedForOpeningDTO
    {
        public CandidateWithQualificationsDTO CandidateWithQualificationsDto { get; set; }
        public ICommand HireCandidateCommand => new RelayCommand(HireCandidate);

        private void HireCandidate()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(CandidateQualifiedForOpeningViewModel)));
            Messenger.Default.Send(new ViewQualifiedCandidatesForOpeningViewMessage());
        }
    }
}
