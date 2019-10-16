using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Services.CompanyService;
using TEC_App.ViewModels;
using TEC_App.Views.CompaniesView;
using TEC_App.Views.UpdateCompanyDetailsView;

namespace TEC_App.Views.CompanyDetailsView
{
    public class CompanyDetailsView_ViewModel : ViewModelBase
    {
        public CompanyDetailsView_ViewModel(ICompanyService companyService)
        {
            Messenger.Default.Register<LoadCompanyDetailsViewMessage>(this, s => NotifyMe(s));
            CompanyService = companyService;
        }

        private void NotifyMe(LoadCompanyDetailsViewMessage loadCompanyDetailsViewMessage)
        {
            Company = loadCompanyDetailsViewMessage.Company;
        }

        public Company Company { get; set; }
        public ICompanyService CompanyService { get; set; }

        public ICommand UpdateCommand => new RelayCommand(UpdateProc);

        private void UpdateProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(UpdateCompanyDetailsView_ViewModel)));
            Messenger.Default.Send(new LoadUpdateCompanyViewMessage(){Company = Company});
        }

        public ICommand DeleteCommand => new RelayCommand(DeleteProc);

        private void DeleteProc()
        {
            if (MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CompanyService.RemoveCompany(Company);
                BackProc();
                
            }
        }
        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(CompaniesView_ViewModel)));
            Messenger.Default.Send(new LoadCompanyViewMessage());
        }
    }
}
