using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Views.SessionsView;

namespace TEC_App.Views.CourseView
{
    public class CourseViewDTO
    {
        public Course Course { get; set; }
        public ICommand ViewCourseDetails => new RelayCommand(ViewCourseDetailsProc);

        private void ViewCourseDetailsProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(SessionsView_ViewModel)));
            Messenger.Default.Send(new LoadSessionsViewMessage(){Course = Course});
        }
    }
}
