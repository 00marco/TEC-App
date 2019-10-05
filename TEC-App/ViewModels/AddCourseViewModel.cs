using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Models.Db;

namespace TEC_App.ViewModels
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
