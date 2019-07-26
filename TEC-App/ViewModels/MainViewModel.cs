using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace TEC_App.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private ViewModelBase _currentVm;

		public MainViewModel()
		{
			CurrentVM = new CandidateView_ViewModel();
		}

		/// <summary>
		/// Responsible for triggering which ViewModel is active?
		/// </summary>
		public ViewModelBase CurrentVM
		{
			get => _currentVm;
			set
			{
				_currentVm = value;
				RaisePropertyChanged(nameof(CurrentVM));
			}
		}

		public CandidateView_ViewModel CandidateView_ViewModel { get; set; }
		public JobOpenings_ViewModel JobOpenings_ViewModel { get; set; }

		public ICommand GotoCandidateViewCommand => new RelayCommand(GotoCandidateViewProc);

		private void GotoCandidateViewProc()
		{
			CurrentVM = new CandidateView_ViewModel();
		}

		public ICommand GotoJobOpeningsViewCommand => new RelayCommand(GotoJobOpeningsViewProc);

		private void GotoJobOpeningsViewProc()
		{
			CurrentVM = new JobOpenings_ViewModel();
		}
	}
}
