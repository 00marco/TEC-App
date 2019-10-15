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
using TEC_App.Services.SessionService;
using TEC_App.Views.CourseView;
using ViewModelBase = TEC_App.ViewModels.ViewModelBase;

namespace TEC_App.Views.SessionsView
{
    public class SessionsView_ViewModel : ViewModelBase
    {
        public SessionsView_ViewModel(ISessionService sessionService)
        {
            SessionService = sessionService;
            Messenger.Default.Register<LoadSessionsViewMessage>(this, s => NotifyMe(s));

        }

        private void NotifyMe(LoadSessionsViewMessage loadSessionsViewMessage)
        {
            Course = loadSessionsViewMessage.Course;
            LoadSessions();
        }

        public Course Course { get; set; }
        public ISessionService SessionService { get; set; }
        public List<SessionViewDTO> Sessions { get; set; } = new List<SessionViewDTO>();

        public void LoadSessions()
        {
            Sessions.Clear();
            foreach (var v in SessionService.GetAllSessionsOfGivenCourseAngMapToViewDTO(Course.Id))
            {
                Sessions.Add(v);
            }
        }
        public ICommand AddNewSessionCommand => new RelayCommand(AddNewSession);
        private void AddNewSession()
        {
        }

        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(CourseView_ViewModel)));
            Messenger.Default.Send(new LoadCourseViewMessage());
        }
    }
}
