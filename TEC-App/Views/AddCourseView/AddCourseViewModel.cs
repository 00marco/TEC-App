using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Services.CourseService;
using TEC_App.Services.PrerequisitesForCourseService;
using TEC_App.Services.QualificationDevelopedByCourseService;
using TEC_App.Services.QualificationsService;
using TEC_App.ViewModels;
using TEC_App.Views.CourseView;

namespace TEC_App.Views.AddCourseView
{
    
    public class AddCourseViewModel : ViewModelBase
    {
        public AddCourseViewModel(IQualificationsService qualificationsService, IPrerequisitesForCourseService prerequisitesForCourseService, IQualificationDevelopedByCourseService qualificationDevelopedByCourseService, ICourseService courseService)
        {
            CourseService = courseService;
            QualificationsService = qualificationsService;
            PrerequisitesForCourseService = prerequisitesForCourseService;
            QualificationDevelopedByCourseService = qualificationDevelopedByCourseService;
            Messenger.Default.Register<LoadAddCourseViewMessage>(this, s => NotifyMe(s));
        }

        private void NotifyMe(LoadAddCourseViewMessage message)
        {
            Course = new Course();
            LoadQualifications();
        }

        public ICourseService CourseService { get; set; }
        public Course Course { get; set; }
        public ObservableCollection<QualificationWithCheckboxViewDto> PrerequisiteQualifications { get; set; } = new ObservableCollection<QualificationWithCheckboxViewDto>();
        public ObservableCollection<QualificationWithCheckboxViewDto> DevelopedQualifications { get; set; } = new ObservableCollection<QualificationWithCheckboxViewDto>();
        public IQualificationsService QualificationsService { get; set; }
        public IPrerequisitesForCourseService PrerequisitesForCourseService { get; set; }
        public IQualificationDevelopedByCourseService QualificationDevelopedByCourseService { get; set; }

        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(CourseView_ViewModel)));
        }

        public void LoadQualifications()
        {
            var prerequisites = QualificationsService.GetAllAndMapToQualificationWithCheckBoxDto();
            var developedQualifications = QualificationsService.GetAllAndMapToQualificationWithCheckBoxDto();
            PrerequisiteQualifications.Clear();
            DevelopedQualifications.Clear();

            foreach (var v in prerequisites)
            {
                PrerequisiteQualifications.Add(v);
            }

            foreach (var v in developedQualifications)
            {
                DevelopedQualifications.Add(v);
            }
        }

        public ICommand AddCommand => new RelayCommand(AddProc);

        private void AddProc()
        {
            if (MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Course = CourseService.AddCourse(Course);
                AddPrerequisites();
                AddQualificationsDeveloped();
            }
        }

        private void AddQualificationsDeveloped()
        {
            foreach (var v in DevelopedQualifications)
            {
                if (v.IsSelected)
                {
                    QualificationDevelopedByCourseService.Add(new QualificationDevelopedByCourse()
                    {
                        Course = Course,
                        Qualification = v.Qualification
                    });
                }
            }
        }

        private void AddPrerequisites()
        {
            foreach (var v in PrerequisiteQualifications)
            {
                if (v.IsSelected)
                {
                    PrerequisitesForCourseService.Add(new PrerequisitesForCourse()
                    {
                        Course = Course,
                        Qualification = v.Qualification
                    });
                }
            }
        }
    }
}
