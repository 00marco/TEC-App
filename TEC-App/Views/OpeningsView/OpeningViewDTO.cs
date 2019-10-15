using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Views.CandidatesQualifiedForOpeningView;

namespace TEC_App.Views.OpeningsView
{
    public class OpeningViewDTO
    {
        public Opening Opening { get; set; }
        public ICommand GotoListOfQualifiedCandidatesViewCommand => new RelayCommand(GotoListOfQualifiedCandidates);

        private void GotoListOfQualifiedCandidates()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(CandidateQualifiedForOpeningViewModel)));
            Messenger.Default.Send(new ViewQualifiedCandidatesForOpeningViewMessage()
            {
                RequiredQualificationId = Opening.RequiredQualificationId
            });
        }
    }
}
