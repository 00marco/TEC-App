using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Views;

namespace TEC_App.ViewModels
{
    public class AddCandidateViewModel : ViewModelBase
    {
        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(nameof(CandidateView_ViewModel)));
        }
    }
}
