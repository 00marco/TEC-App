using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.DTO;
using TEC_App.Services.PlacementService;
using TEC_App.ViewModels;

namespace TEC_App.Views.PlacementsView
{
	public class PlacementsView_ViewModel : ViewModelBase
    {
        public PlacementsView_ViewModel(IPlacementService placementService)
        {
            PlacementService = placementService;
            Messenger.Default.Register<LoadPlacementsViewMessage>(this, s => NotifyMe(s));
        }

        public IPlacementService PlacementService { get; set; }
        private void NotifyMe(LoadPlacementsViewMessage message)
        {
            LoadPlacements();
        }
        public ObservableCollection<PlacementViewDTO> PlacementViewDtos { get; set; } =
		    new ObservableCollection<PlacementViewDTO>();

        public void LoadPlacements()
        {
            var placements = PlacementService.GetAllPlacementViewDtos();
            PlacementViewDtos.Clear();
            foreach (var v in placements)
            {
                PlacementViewDtos.Add(v);
            }
        }

    }
}
