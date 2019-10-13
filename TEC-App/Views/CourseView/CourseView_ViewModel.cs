using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.DTO;
using TEC_App.Services.CourseService;
using TEC_App.ViewModels;
using TEC_App.Views.AddCourseView;

namespace TEC_App.Views.CourseView
{
	public class CourseView_ViewModel : ViewModelBase
	{
        public CourseView_ViewModel(ICourseService _courseService)
        {
            Messenger.Default.Register<LoadCourseViewMessage>(this, s => NotifyMe(s));
            CourseService = _courseService;
        }

        public ICourseService CourseService { get; set; }

        private void NotifyMe(LoadCourseViewMessage message)
        {
            LoadCourseViewDtos();
            
        }

        public ObservableCollection<CourseWithLocationDTO> CourseViewDtos { get; set; } =
			new ObservableCollection<CourseWithLocationDTO>();
        public ICommand AddCourseCommand => new RelayCommand(AddCourse);

        private void AddCourse()
        {

            Messenger.Default.Send(new NotificationMessage(nameof(AddCourseViewModel)));
        }

        public void LoadCourseViewDtos()
        {
            //var courseViewDtos = CourseService.GetCourseViewDtoList();
            //CourseViewDtos.Clear();
            //foreach (var v in courseViewDtos)
            //{
            //    CourseViewDtos.Add(v);
            //}
        }
    }
}
