using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.DTO;
using TEC_App.ViewModels;

namespace TEC_App.Views.PlacementsView
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
