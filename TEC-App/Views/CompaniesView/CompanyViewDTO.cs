using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Views.CompanyDetailsView;

namespace TEC_App.Views.CompaniesView
{
    public class CompanyViewDTO
    {
        public Company Company { get; set; }
        public ICommand GotoCompanyDetailsCommand => new RelayCommand(GotoCompanyDetailsProc);

        private void GotoCompanyDetailsProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(CompanyDetailsView_ViewModel)));
            Messenger.Default.Send(new LoadCompanyDetailsViewMessage(){Company = Company});
        }
    }
}
