using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.DTO;
using TEC_App.Services.CompanyService;
using TEC_App.ViewModels;
using TEC_App.Views.AddCompanyView;

namespace TEC_App.Views.CompaniesView
{
	public class CompaniesView_ViewModel : ViewModelBase
	{
	    public CompaniesView_ViewModel(ICompanyService companyService)
	    {
		    Test = "Test";
            CompanyService = companyService;
            Messenger.Default.Register<LoadCompanyViewMessage>(this, s => NotifyMe(s));
        }

        public ICompanyService CompanyService { get; set; }
        private void NotifyMe(LoadCompanyViewMessage message)
        {
            LoadCompanies();
            
        }

        public ObservableCollection<CompanyViewDTO> CompanyViewDtos { get; set; } =
		    new ObservableCollection<CompanyViewDTO>();
		

		public string Test { get; set; }
        public ICommand AddCompanyCommand => new RelayCommand(AddCompany);

        private void AddCompany()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(AddCompanyViewModel)));
            Messenger.Default.Send(new LoadAddCompanyViewMessage());
        }

        public void LoadCompanies()
        {
            var companies = CompanyService.GetAllCompanyViewDtos();
            CompanyViewDtos.Clear();
            foreach (var v in companies)
            {
                CompanyViewDtos.Add(v);
            }
        }
    }
}
