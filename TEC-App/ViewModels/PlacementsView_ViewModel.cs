using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.DTO;

namespace TEC_App.ViewModels
{
	public class PlacementsView_ViewModel : ViewModelBase
    {
	    public ObservableCollection<PlacementWithCandidateDTO> PlacementViewDtos { get; set; } =
		    new ObservableCollection<PlacementWithCandidateDTO>();

    }
}
