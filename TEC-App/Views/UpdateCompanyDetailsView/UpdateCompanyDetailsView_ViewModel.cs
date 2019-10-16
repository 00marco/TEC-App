using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Services.CompanyService;
using TEC_App.ViewModels;
using TEC_App.Views.CompanyDetailsView;

namespace TEC_App.Views.UpdateCompanyDetailsView
{
    public class UpdateCompanyDetailsView_ViewModel : ViewModelBase
    {
        public UpdateCompanyDetailsView_ViewModel(ICompanyService companyService)
        {
            Messenger.Default.Register<LoadUpdateCompanyViewMessage>(this, s => NotifyMe(s));
            CompanyService = companyService;
        }
        

        private void NotifyMe(LoadUpdateCompanyViewMessage loadUpdateCompanyViewMessage)
        {
            OldCompany = loadUpdateCompanyViewMessage.Company;
            NewCompany = DeepCopyForCompany(OldCompany);
        }

        public ICompanyService CompanyService { get; set; }
        public Company OldCompany { get; set; }
        public Company NewCompany { get; set; }

        public Company DeepCopyForCompany(Company company)
        {
            return new Company()
            {
                Name = company.Name,
                Timestamp = company.Timestamp
            };
        }

        public ICommand UpdateCommand => new RelayCommand(UpdateProc);

        private void UpdateProc()
        {
            var company = CompanyService.UpdateCompany(OldCompany, NewCompany);
            BackProc();
            
        }
        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(CompanyDetailsView_ViewModel)));
            Messenger.Default.Send(new LoadCompanyDetailsViewMessage(){Company = OldCompany});
        }
    }
}
