using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEC_App.ViewModels
{
    public class CompaniesView_ViewModel : ViewModelBase
	{
	    public CompaniesView_ViewModel()
	    {
		    Test = "Test";
	    }
	    public string Test { get; set; }
    }
}
