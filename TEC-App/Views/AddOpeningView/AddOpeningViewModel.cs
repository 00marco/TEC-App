using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Models.Db;
using TEC_App.ViewModels;
using TEC_App.Views.OpeningsView;

namespace TEC_App.Views.AddOpeningView
{
    public class AddOpeningViewModel : ViewModelBase
    {
        public Opening Opening { get; set; }
        public List<Company> Companies { get; set; }

        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(OpeningsView_ViewModel)));
        }

    }
}
