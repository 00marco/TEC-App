using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Services.AddressService;
using TEC_App.Services.CourseService;
using TEC_App.Services.LocationService;
using TEC_App.Services.SessionLocationService;
using TEC_App.Services.SessionService;
using TEC_App.ViewModels;
using TEC_App.Views.AddCourseView;
using TEC_App.Views.SessionsView;

namespace TEC_App.Views.AddSessionView
{
    public class AddSession_ViewModel : ViewModelBase
    {
        public AddSession_ViewModel(ICourseService courseService, ISessionService sessionService, ISessionLocationService sessionLocationService, ILocationService locationService, IAddressService addressService)
        {
            CourseService = courseService;
            SessionService = sessionService;
            AddressService = addressService;
            SessionLocationService = sessionLocationService;
            LocationService = locationService;
            Messenger.Default.Register<LoadAddSessionMessage>(this, NotifyMe);

        }

        private void NotifyMe(LoadAddSessionMessage obj)
        {
            LoadContents(obj);
        }

        public IAddressService AddressService { get; set; }
        public ILocationService LocationService { get; set; }
        public ISessionLocationService SessionLocationService { get; set; }
        public ICourseService CourseService { get; set; }
        public ISessionService SessionService { get; set; }
        public Session Session { get; set; }
        public Course SelectedCourse { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public int VenueCapacity { get; set; }
        public string VenueAddress { get; set; }

        public void LoadContents(LoadAddSessionMessage obj)
        {
            SelectedCourse = obj.Course;
            Session = new Session()
            {
                Course = SelectedCourse,
                DateTimeStart = DateTime.Now,
                DateTimeEnd = DateTime.Now.AddDays(5),
            };
            Courses.Clear();
            foreach (var v in CourseService.GetAllCourses())
            {
                Courses.Add(v);
            }
        }

        public ICommand AddSessionCommand => new RelayCommand(AddSession);

        private void AddSession()
        {
            if (MessageBox.Show("Are you sure", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var sessions = SessionService.GetAllSessions().Where(d => d.CourseId == SelectedCourse.Id);
                if (ScheduleConflict(sessions))
                {
                    //if Session Start is within Start and End of existing session for the same course - there is a schedule conflict and the operation must not be allowed
                    MessageBox.Show("Schedule Conflict");
                    return;
                }
                //create location from strings
                var address = AddressService.AddAddress(new Address()
                {
                    ZipCode = VenueAddress,
                });
                var location = LocationService.AddLocation(new Location()
                {
                    Address = address,
                    Capacity = VenueCapacity
                });
                Session = SessionService.AddSession(Session);
                var sessionLocation = SessionLocationService.Add(new Session_Location()
                {
                    Session = Session,
                    Location = location
                });
                BackProc();
            }

        }

        private bool ScheduleConflict(IEnumerable<Session> sessions)
        {
            if (sessions.Any(d =>
                Session.DateTimeStart >= d.DateTimeStart && Session.DateTimeStart < d.DateTimeEnd ||
                Session.DateTimeEnd >= d.DateTimeStart && Session.DateTimeEnd < d.DateTimeEnd || 
                Session.DateTimeStart < d.DateTimeStart && Session.DateTimeEnd > d.DateTimeEnd))
            {
                return true;
            }

            return false;
        }

        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(SessionsView_ViewModel)));
            Messenger.Default.Send(new LoadSessionsViewMessage(){Course = SelectedCourse});
        }
    }
}
