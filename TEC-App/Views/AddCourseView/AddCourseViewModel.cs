using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Models.ViewDTO;
using TEC_App.Services.CourseService;
using TEC_App.Services.PrerequisitesForCourseService;
using TEC_App.Services.QualificationDevelopedByCourseService;
using TEC_App.Services.QualificationsService;
using TEC_App.Services.SessionService;
using TEC_App.ViewModels;
using TEC_App.Views.AddSessionView;
using TEC_App.Views.CourseView;
using TEC_App.Views.SessionsView;

namespace TEC_App.Views.AddCourseView
{
    
    public class AddCourseViewModel : ViewModelBase
    {
        public AddCourseViewModel(IQualificationsService qualificationsService, IPrerequisitesForCourseService prerequisitesForCourseService, IQualificationDevelopedByCourseService qualificationDevelopedByCourseService, ICourseService courseService, ISessionService sessionService)
        {
            CourseService = courseService;
            QualificationsService = qualificationsService;
            PrerequisitesForCourseService = prerequisitesForCourseService;
            QualificationDevelopedByCourseService = qualificationDevelopedByCourseService;
            SessionService = sessionService;
            Messenger.Default.Register<LoadAddCourseViewMessage>(this, s => NotifyMe(s));
        }

        private void LoadSessions()
        {

            Sessions.Clear();
            foreach (var v in SessionService.GetAllSessionsOfGivenCourseAndMapToViewDTO(Course.Id))
            {
                Sessions.Add(v);
            }

        }

        private void NotifyMe(LoadAddCourseViewMessage message)
        {
            if (message.ReloadCourse)
            {
                Course = new Course();
            }
            LoadQualifications();
            LoadSessions();
        }

        public QualificationWithCheckboxViewDto SelectedQualification { get; set; }
        public List<SessionViewDTO> Sessions { get; set; } = new List<SessionViewDTO>();
        public ICourseService CourseService { get; set; }
        public Course Course { get; set; }
        public ObservableCollection<QualificationWithCheckboxViewDto> PrerequisiteQualifications { get; set; } = new ObservableCollection<QualificationWithCheckboxViewDto>();
        public ObservableCollection<QualificationWithCheckboxViewDto> DevelopedQualifications { get; set; } = new ObservableCollection<QualificationWithCheckboxViewDto>();
        public IQualificationsService QualificationsService { get; set; }
        public IPrerequisitesForCourseService PrerequisitesForCourseService { get; set; }
        public IQualificationDevelopedByCourseService QualificationDevelopedByCourseService { get; set; }
        public ISessionService SessionService { get; set; }


        public ICommand AddSessionCommand => new RelayCommand(AddSessionProc);

        private void AddSessionProc()
        {
            if (string.IsNullOrEmpty(Course.Name))
            {
                MessageBox.Show("Name cannot be empty");
                return;
            }
            Messenger.Default.Send(new NotificationMessage(nameof(AddSession_ViewModel)));
            Messenger.Default.Send(new LoadAddSessionMessage() { Course = Course });

        }

        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(CourseView_ViewModel)));
        }

        public void LoadQualifications()
        {
            SelectedQualification = new QualificationWithCheckboxViewDto();
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
                Messenger.Default.Send(new NotificationMessage(nameof(SessionsView_ViewModel)));
                Messenger.Default.Send(new LoadSessionsViewMessage() { Course = Course });
            }
        }

        private void AddQualificationsDeveloped()
        {
            QualificationDevelopedByCourseService.Add(new QualificationDevelopedByCourse()
            {
                Course = Course,
                Qualification = SelectedQualification.Qualification
            });
            //foreach (var v in DevelopedQualifications)
            //{
            //    if (v.IsSelected)
            //    {
            //        QualificationDevelopedByCourseService.Add(new QualificationDevelopedByCourse()
            //        {
            //            Course = Course,
            //            Qualification = v.Qualification
            //        });
            //    }
            //}
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
