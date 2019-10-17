using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Services.PlacementService;
using TEC_App.ViewModels;
using TEC_App.Views.PlacementsView;

namespace TEC_App.Views.UpdatePlacementView
{
    public class UpdatePlacementView_ViewModel : ViewModelBase
    {
        public UpdatePlacementView_ViewModel(IPlacementService placementService)
        {
            PlacementService = placementService;
            Messenger.Default.Register<LoadUpdatePlacementViewMessage>(this, s => NotifyMe(s));
        }

        private void NotifyMe(LoadUpdatePlacementViewMessage loadUpdatePlacementViewMessage)
        {
            SelectedPlacement = loadUpdatePlacementViewMessage.SelectedPlacement;
            LoadPlacement();
            
        }

        public Placement SelectedPlacement { get; set; }
        public Placement NewPlacement { get; set; }
        public IPlacementService PlacementService { get; set; }


        public void LoadPlacement()
        {
            NewPlacement = DeepCopyForPlacement(SelectedPlacement);
        }
        public Placement DeepCopyForPlacement(Placement selectedPlacement)
        {
            return new Placement()
            {
                Candidate = selectedPlacement.Candidate,
                Opening = selectedPlacement.Opening,
                Timestamp = selectedPlacement.Timestamp,
                TotalHoursWorked = selectedPlacement.TotalHoursWorked
            };
        }
        public ICommand UpdatePlacement => new RelayCommand(UpdateProc);
        private void UpdateProc()
        {
            var duration = (SelectedPlacement.Opening.DateTimeEnd - SelectedPlacement.Opening.DateTimeStart).TotalHours;
            if (NewPlacement.TotalHoursWorked > duration)
            {
                MessageBox.Show($"Number of hours worked cannot exceed duration of the Opening ({duration} hours)");
                return;
            }
            if (MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                NewPlacement.Timestamp = DateTime.Now;
                PlacementService.UpdatePlacement(SelectedPlacement, NewPlacement);
                BackProc();
            }
        }

        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(PlacementsView_ViewModel)));
            Messenger.Default.Send(new LoadPlacementsViewMessage());

        }
    }
}
