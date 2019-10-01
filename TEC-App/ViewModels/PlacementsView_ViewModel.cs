using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEC_App.ViewModels
{
	public class PlacementViewDTO
	{
		public string CandidateName { get; set; }
		public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }
		public float HoursWorked { get; set; }
		public float Payment { get; set; }

	}
    public class PlacementsView_ViewModel : ViewModelBase
    {
	    public ObservableCollection<PlacementViewDTO> PlacementViewDtos { get; set; } =
		    new ObservableCollection<PlacementViewDTO>();

    }
}
