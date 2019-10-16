using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Services.OpeningsService;
using TEC_App.ViewModels;
using TEC_App.Views.AddOpeningView;

namespace TEC_App.Views.OpeningsView
{
	public class OpeningsView_ViewModel : ViewModelBase
    {
        public OpeningsView_ViewModel(IOpeningsService openingsService)
        {
            OpeningsService = openingsService;
            Messenger.Default.Register<LoadOpeningsViewMessage>(this, s => NotifyMe(s));
        }

        public IOpeningsService OpeningsService { get; set; }
        private void NotifyMe(LoadOpeningsViewMessage message)
        {
            LoadOpenings();

        }

        private void LoadOpenings()
        {
            Openings.Clear();
            var openings = OpeningsService.GetAllOpeningsAsViewDtos();
            foreach (var v in openings)
            {
                if (v.Opening.IsOpen )
                {
                    Openings.Add(v);
                }
            }
        }

        public ObservableCollection<OpeningViewDTO> Openings { get; set; } = new ObservableCollection<OpeningViewDTO>();
		

        public ICommand AddOpeningCommand => new RelayCommand(AddOpeningProc);

        private void AddOpeningProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(AddOpeningViewModel)));
            Messenger.Default.Send(new LoadAddOpeningViewMessage());
        }
    }
}
