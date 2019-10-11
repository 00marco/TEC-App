using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.DTO;
using TEC_App.ViewModels;
using TEC_App.Views.AddCourseView;

namespace TEC_App.Views.CourseView
{
	public class CourseView_ViewModel : ViewModelBase
	{
        public CourseView_ViewModel()
        {
            Messenger.Default.Register<LoadCourseViewMessage>(this, s => NotifyMe(s));
        }

        private void NotifyMe(LoadCourseViewMessage message)
        {
            MessageBox.Show("Load course view");

        }

        public ObservableCollection<CourseWithLocationDTO> CourseViewDtos { get; set; } =
			new ObservableCollection<CourseWithLocationDTO>();
        public ICommand AddCourseCommand => new RelayCommand(AddCourse);

        private void AddCourse()
        {

            Messenger.Default.Send(new NotificationMessage(nameof(AddCourseViewModel)));
        }
    }
}
