using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Models.Db;
using TEC_App.ViewModels;
using TEC_App.Views.CompaniesView;

namespace TEC_App.Views.AddCompanyView
{
    public class AddCompanyViewModel : ViewModelBase
    {
        public Company Company { get; set; }

        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(CompaniesView_ViewModel)));
        }
    }
}
