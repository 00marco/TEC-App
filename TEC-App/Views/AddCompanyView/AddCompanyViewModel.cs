using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Services.CompanyService;
using TEC_App.ViewModels;
using TEC_App.Views.CompaniesView;

namespace TEC_App.Views.AddCompanyView
{
    public class AddCompanyViewModel : ViewModelBase
    {
        public AddCompanyViewModel(ICompanyService companyService)
        {
            CompanyService = companyService;
            Messenger.Default.Register<LoadAddCompanyViewMessage>(this, NotifyMe);
        }

        private void NotifyMe(LoadAddCompanyViewMessage obj)
        {
            LoadContents();
        }

        public Company Company { get; set; }
        public ICompanyService CompanyService { get; set; }



        public void LoadContents()
        {
            Company = new Company();
        }

        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(CompaniesView_ViewModel)));
        }

        public ICommand AddCommand => new RelayCommand(AddProc);

        private void AddProc()
        {

            if (MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Company.Timestamp = DateTime.Now;
                Company = CompanyService.AddCompany(Company);
                BackProc();
            }
        }
    }
}
