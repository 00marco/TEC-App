using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Models.DTO;

namespace TEC_App.ViewModels
{
	public class CompaniesView_ViewModel : ViewModelBase
	{
	    public CompaniesView_ViewModel()
	    {
		    Test = "Test";
	    }

	    public ObservableCollection<CompanyViewDTO> CompanyViewDtos { get; set; } =
		    new ObservableCollection<CompanyViewDTO>();
		public ICommand FullCompanyDetailsDTO => new RelayCommand(GotoFullCompanyDetailsProc);

		private void GotoFullCompanyDetailsProc()
		{
			throw new NotImplementedException();
		}

		public string Test { get; set; }
        public ICommand AddCompanyCommand => new RelayCommand(AddCompany);

        private void AddCompany()
        {
            
            Messenger.Default.Send(new NotificationMessage(nameof(AddCompanyViewModel)));
        }
    }
}
