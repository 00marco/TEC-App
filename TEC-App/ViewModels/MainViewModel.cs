using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;

namespace TEC_App.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private ViewModelBase _currentVm;

		public MainViewModel()
		{
			CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<OpeningsView_ViewModel>();
            Messenger.Default.Send(new LoadOpeningsViewMessage());
			Messenger.Default.Register<NotificationMessage>(this, NotifyMe);
        }

		private void NotifyMe(NotificationMessage message)
		{
			switch (message.Notification)
			{
				case nameof(IndividualCandidateDetailsView_ViewModel):
					CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<IndividualCandidateDetailsView_ViewModel>();
					break;

				case nameof(OpeningsView_ViewModel):
					CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<OpeningsView_ViewModel>();
					break;
				case nameof(CandidateView_ViewModel):
					CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<CandidateView_ViewModel>();
					break;
				case nameof(CourseView_ViewModel):
					CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<CourseView_ViewModel>();

					break;
				case nameof(CompaniesView_ViewModel):
					CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<CompaniesView_ViewModel>();

					break;
				case nameof(PlacementsView_ViewModel):
					CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<PlacementsView_ViewModel>();

					break;
                case nameof(AddCandidateViewModel):
                    CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<AddCandidateViewModel>();

                    break;
                case nameof(AddCompanyViewModel):
                    CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<AddCompanyViewModel>();

                    break;
                case nameof(AddCourseViewModel):
                    CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<AddCourseViewModel>();

                    break;
                case nameof(AddOpeningViewModel):
                    CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<AddOpeningViewModel>();

                    break;
                case nameof(CandidateQualifiedForOpeningViewModel):
                    CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<CandidateQualifiedForOpeningViewModel>();

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
			CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<CandidateView_ViewModel>();
			Messenger.Default.Send(new LoadCandidateViewMessage());
		}

		public ICommand GotoCompaniesViewCommand => new RelayCommand(GotoCompaniesViewProc);

		private void GotoCompaniesViewProc()
		{
			CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<CompaniesView_ViewModel>();
            Messenger.Default.Send(new LoadCompanyViewMessage());

        }

        public ICommand GotoCourseViewCommand => new RelayCommand(GotoCourseViewProc);

		private void GotoCourseViewProc()
		{
			CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<CourseView_ViewModel>();
            Messenger.Default.Send(new LoadCourseViewMessage());

        }

        public ICommand GotoOpeningsViewCommand => new RelayCommand(GotoOpeningsViewProc);

		private void GotoOpeningsViewProc()
		{
			CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<OpeningsView_ViewModel>();
            Messenger.Default.Send(new LoadOpeningsViewMessage());

        }

        public ICommand GotoPlacementsViewCommand => new RelayCommand(GotoPlacementsViewProc);

		private void GotoPlacementsViewProc()
		{
			CurrentVM = CommonServiceLocator.ServiceLocator.Current.GetInstance<PlacementsView_ViewModel>();
            Messenger.Default.Send(new LoadPlacementsViewMessage());

        }
    }
}
