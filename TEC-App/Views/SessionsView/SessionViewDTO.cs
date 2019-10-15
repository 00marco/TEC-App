using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Views.SessionAttendanceView;

namespace TEC_App.Views.SessionsView
{
    public class SessionViewDTO
    {
        public Session Session { get; set; }
        public ICommand GotoAttendanceViewCommand => new RelayCommand(GotoAttendanceProc);

        private void GotoAttendanceProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(SessionAttendanceView_ViewModel)));
            Messenger.Default.Send(new LoadSessionAttendanceViewMessage(){Session = Session});
        }
    }
}
