using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace TEC_App.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private ViewModelBase _currentVm;

		public MainViewModel()
		{
			CurrentVM = new OpeningsView_ViewModel();
			Messenger.Default.Register<NotificationMessage>(this, NotifyMe);
		}

		private void NotifyMe(NotificationMessage message)
		{
			switch (message.Notification)
			{
				case nameof(OpeningsView_ViewModel):
					CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<OpeningsView_ViewModel>();
					break;
				case nameof(CandidateView_ViewModel):
					CurrentVM = CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<CandidateView_ViewModel>();
					break;
				case nameof(CourseView_ViewModel):
					CurrentVM = CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<CourseView_ViewModel>();

					break;
				case nameof(CompaniesView_ViewModel):
					CurrentVM = CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<CompaniesView_ViewModel>();

					break;
				case nameof(PlacementsView_ViewModel):
					CurrentVM = CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<PlacementsView_ViewModel>();

					break;
				default:
					MessageBox.Show($"{message.Notification} notification message error. Not recognized");
					CurrentVM = new OpeningsView_ViewModel();
					break;

			}

		}

		public ViewModelBase CurrentVM
		{
			get => _currentVm;
			set
			{
				_currentVm = value;
				RaisePropertyChanged(nameof(CurrentVM));
			}
		}

		public ICommand GotoCandidateViewCommand => new RelayCommand(GotoCandidateViewProc);

		private void GotoCandidateViewProc()
		{
			CurrentVM = new CandidateView_ViewModel();
		}

		public ICommand GotoCompaniesViewCommand => new RelayCommand(GotoCompaniesViewProc);

		private void GotoCompaniesViewProc()
		{
			CurrentVM = new CompaniesView_ViewModel();
		}

		public ICommand GotoCourseViewCommand => new RelayCommand(GotoCourseViewProc);

		private void GotoCourseViewProc()
		{
			CurrentVM = new CourseView_ViewModel();
		}

		public ICommand GotoOpeningsViewCommand => new RelayCommand(GotoOpeningsViewProc);

		private void GotoOpeningsViewProc()
		{
			CurrentVM = new OpeningsView_ViewModel();
		}

		public ICommand GotoPlacementsViewCommand => new RelayCommand(GotoPlacementsViewProc);

		private void GotoPlacementsViewProc()
		{
			CurrentVM = new PlacementsView_ViewModel();
		}
	}
}
