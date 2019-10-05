using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Models.Db;

namespace TEC_App.ViewModels
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
