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

namespace TEC_App.ViewModels
{
	public class OpeningsView_ViewModel : ViewModelBase
    {
        public OpeningsView_ViewModel()
        {
            Messenger.Default.Register<LoadOpeningsViewMessage>(this, s => NotifyMe(s));
        }

        private void NotifyMe(LoadOpeningsViewMessage message)
        {
            MessageBox.Show("Load openings view");

        }
        public ObservableCollection<CompanyWithOpeningDetailsDTO> CompanyOpeningDtos { get; set; } =
		    new ObservableCollection<CompanyWithOpeningDetailsDTO>();

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
