using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.DTO;
using TEC_App.Services.PlacementService;
using TEC_App.ViewModels;
using TEC_App.Views.UpdatePlacementView;

namespace TEC_App.Views.PlacementsView
{
	public class PlacementsView_ViewModel : ViewModelBase
    {
        public PlacementsView_ViewModel(IPlacementService placementService)
        {
            PlacementService = placementService;
            Messenger.Default.Register<LoadPlacementsViewMessage>(this, s => NotifyMe(s));
        }

        public PlacementViewDTO SelectedPlacementViewDTO { get; set; }
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
        public ICommand UpdatePlacementCommand => new RelayCommand(UpdateProc);

        private void UpdateProc()
        {
            if (SelectedPlacementViewDTO == null)
            {
                MessageBox.Show("Please select a placement record");
                return;
            }
            Messenger.Default.Send(new NotificationMessage(nameof(UpdatePlacementView_ViewModel)));
            Messenger.Default.Send(new LoadUpdatePlacementViewMessage(){SelectedPlacement = SelectedPlacementViewDTO.Placement});

        }
    }
}
