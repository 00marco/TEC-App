using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.DTO;
using TEC_App.Models.ViewDTO;
using TEC_App.Services.OpeningsService;

namespace TEC_App.ViewModels
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
            var openings = OpeningsService.GetOpeningViewDTOList();
            CompanyOpeningDtos = new ObservableCollection<OpeningViewDTO>(openings);
        }

        public ObservableCollection<OpeningViewDTO> CompanyOpeningDtos { get; set; } =
		    new ObservableCollection<OpeningViewDTO>();

		public ICommand GotoListOfQualifiedCandidatesForOpeningCommand => new RelayCommand(GotoListOfQualifiedCandidatesForOpeningProc);

		private void GotoListOfQualifiedCandidatesForOpeningProc()
		{
			throw new NotImplementedException();
		}

        public ICommand AddOpeningCommand => new RelayCommand(AddOpeningProc);

        private void AddOpeningProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(AddOpeningViewModel)));
        }
    }
}
