using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Models.Db;
using TEC_App.ViewModels;
using TEC_App.Views.CourseView;

namespace TEC_App.Views.AddCourseView
{
    
    public class AddCourseViewModel : ViewModelBase
    {
        public Course Course { get; set; }
        public ObservableCollection<Qualification> PrerequisiteQualifications { get; set; }
        public ObservableCollection<Qualification> DevelopedQualifications { get; set; }


        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(CourseView_ViewModel)));
        }

    }
}
