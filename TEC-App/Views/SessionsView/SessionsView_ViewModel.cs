using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Services.CandidateSessionService;
using TEC_App.Services.CourseService;
using TEC_App.Services.PrerequisitesForCourseService;
using TEC_App.Services.QualificationDevelopedByCourseService;
using TEC_App.Services.QualificationsService;
using TEC_App.Services.SessionLocationService;
using TEC_App.Services.SessionService;
using TEC_App.Views.AddSessionView;
using TEC_App.Views.CourseView;
using ViewModelBase = TEC_App.ViewModels.ViewModelBase;

namespace TEC_App.Views.SessionsView
{
    public class SessionsView_ViewModel : ViewModelBase
    {
        public SessionsView_ViewModel(ISessionService sessionService, ICourseService courseService, ICandidateSessionService candidateSessionService, ISessionLocationService sessionLocationService, IQualificationDevelopedByCourseService qualificationsDevelopedByCourseService, IPrerequisitesForCourseService prerequisitesForCourseService)
        {
            SessionService = sessionService;
            CourseService = courseService;
            CandidateSessionService = candidateSessionService;
            SessionLocationService = sessionLocationService;
            QualificationDevelopedByCourseService = qualificationsDevelopedByCourseService;
            PrerequisitesForCourseService = prerequisitesForCourseService;
            Messenger.Default.Register<LoadSessionsViewMessage>(this, s => NotifyMe(s));

        }

        private void NotifyMe(LoadSessionsViewMessage loadSessionsViewMessage)
        {
            Course = loadSessionsViewMessage.Course;
            LoadSessions();
            LoadQualifications();
            
        }

        public Course Course { get; set; }
        public ISessionService SessionService { get; set; }
        public ICourseService CourseService { get; set; }
        public ICandidateSessionService CandidateSessionService { get; set; }
        public ISessionLocationService SessionLocationService { get; set; }
        public IQualificationDevelopedByCourseService QualificationDevelopedByCourseService { get; set; }
        public IPrerequisitesForCourseService PrerequisitesForCourseService { get; set; }
        public List<SessionViewDTO> Sessions { get; set; } = new List<SessionViewDTO>();
        public string QualificationString { get; set; }

        public void LoadSessions()
        {
            Sessions.Clear();
            foreach (var v in SessionService.GetAllSessionsOfGivenCourseAndMapToViewDTO(Course.Id))
            {
                Sessions.Add(v);
            }
        }
        public void LoadQualifications()
        {
            var qualificationsDevelopedByCourse = Course.QualificationsDevelopedByCourse.Where(d => d.CourseId == Course.Id);
            var qualifications = new List<string>();
            foreach (var v in qualificationsDevelopedByCourse)
            {
                qualifications.Add(v.Qualification.Code);
            }

            QualificationString = string.Join(", ", qualifications);

        }
        public ICommand AddNewSessionCommand => new RelayCommand(AddNewSession);
        private void AddNewSession()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(AddSession_ViewModel)));
            Messenger.Default.Send(new LoadAddSessionMessage(){Course = Course});
        }

        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(CourseView_ViewModel)));
            Messenger.Default.Send(new LoadCourseViewMessage());
        }

        public ICommand DeleteCourseCommand => new RelayCommand(DeleteCourseProc);

        private void DeleteCourseProc()
        {
            if (MessageBox.Show("Are you sure?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //remove course
                //remove session
                //remove candidatesession
                //remove sessionlocation
                //remove qualificationsdevelopedbycourse
                //remove prerequisitesforcourse
                foreach (var v in CandidateSessionService.GetAll().Where(d => d.Session.CourseId == Course.Id))
                {
                    CandidateSessionService.Remove(v.CandidateId, v.SessionId);
                }

                foreach (var v in SessionService.GetAllSessions().Where(d => d.CourseId == Course.Id))
                {
                    SessionService.RemoveSession(v);
                }

                foreach (var v in SessionLocationService.GetAll().Where(d => d.Session.CourseId == Course.Id))
                {
                    SessionLocationService.Remove(v.SessionId, v.LocationId);
                }

                foreach (var v in SessionLocationService.GetAll().Where(d => d.Session.CourseId == Course.Id))
                {
                    SessionLocationService.Remove(v.SessionId, v.LocationId);
                }

                foreach (var v in QualificationDevelopedByCourseService.GetAll().Where(d => d.CourseId == Course.Id))
                {
                    QualificationDevelopedByCourseService.Remove(Course.Id, v.QualificationId);
                }

                foreach (var v in PrerequisitesForCourseService.GetAll().Where(d => d.CourseId == Course.Id))
                {
                    PrerequisitesForCourseService.Remove(Course.Id, v.QualificationId);
                }
                CourseService.RemoveCourse(Course);

                BackProc();
            }
        }
    }
}
