using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace TEC_App.ViewModels
{
	public class CompanyViewDTO
	{
		public string CompanyNAme { get; set; }
		public string OpeningsByCompany { get; set; }
		public string OngoingJobsByCompany { get; set; }
		public string SatisfiedJobsByCompany { get; set; }

	}
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

    }
}
