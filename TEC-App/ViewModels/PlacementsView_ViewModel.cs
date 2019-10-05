using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.DTO;

namespace TEC_App.ViewModels
{
	public class PlacementsView_ViewModel : ViewModelBase
    {
        public PlacementsView_ViewModel()
        {
            Messenger.Default.Register<LoadPlacementsViewMessage>(this, s => NotifyMe(s));
        }

        private void NotifyMe(LoadPlacementsViewMessage message)
        {
            MessageBox.Show("Load placements view");

        }
        public ObservableCollection<PlacementWithCandidateDTO> PlacementViewDtos { get; set; } =
		    new ObservableCollection<PlacementWithCandidateDTO>();

    }
}
