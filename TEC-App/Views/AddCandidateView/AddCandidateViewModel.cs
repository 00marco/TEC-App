using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Models.Db;
using TEC_App.ViewModels;
using TEC_App.Views.CandidateView;

namespace TEC_App.Views.AddCandidateView
{
    public class AddCandidateViewModel : ViewModelBase
    {
        public Candidate Candidate { get; set; }
        public Address Address1 { get; set; }
        public Address Address2 { get; set; }
        public Address Address3 { get; set; }

        public ICommand BackCommand => new RelayCommand(BackProc);
        private void BackProc()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(nameof(CandidateView_ViewModel)));
        }
    }
}
