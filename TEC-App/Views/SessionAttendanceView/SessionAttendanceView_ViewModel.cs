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
using TEC_App.Models.ViewDTO;
using TEC_App.Services.CandidateSessionService;
using TEC_App.Services.EmployeeService;
using TEC_App.ViewModels;
using TEC_App.Views.SessionsView;

namespace TEC_App.Views.SessionAttendanceView
{
    public class SessionAttendanceView_ViewModel : ViewModelBase
    {
        public SessionAttendanceView_ViewModel(ICandidateSessionService candidateSessionService, ICandidateService candidateService)
        {
            Messenger.Default.Register<LoadSessionAttendanceViewMessage>(this, s => NotifyMe(s));
            CandidateSessionService = candidateSessionService;
            CandidateService = candidateService;
        }

        private void NotifyMe(LoadSessionAttendanceViewMessage loadSessionAttendanceViewMessage)
        {
            SelectedSession = loadSessionAttendanceViewMessage.Session;
            LoadContents(loadSessionAttendanceViewMessage);
        }

        private void LoadContents(LoadSessionAttendanceViewMessage loadSessionAttendanceViewMessage)
        {
            CandidateWithCheckBoxDtos.Clear();
            foreach (var v in CandidateService.GetAllCandidatesAndMapToCandidateWithCheckBoxDTO())
            {
                CandidateWithCheckBoxDtos.Add(v);
            }
        }

        public Session SelectedSession { get; set; }
        public ICandidateSessionService CandidateSessionService { get; set; }
        public ICandidateService CandidateService { get; set; }
        public List<CandidateWithCheckBoxDTO> CandidateWithCheckBoxDtos { get; set; } = new List<CandidateWithCheckBoxDTO>();

        public ICommand ConfirmAttendanceCommand => new RelayCommand(ConfirmAttendanceProc);
        private void ConfirmAttendanceProc()
        {
            foreach (var v in CandidateWithCheckBoxDtos)
            {
                if (v.IsSelected)
                {
                    CandidateSessionService.Add(new Candidate_Session()
                    {
                        Candidate = v.Candidate,
                        Session = SelectedSession
                    });
                }
            }

            var candidateSessions = CandidateSessionService.GetAll();
        }

        public ICommand BackCommand => new RelayCommand(BackProc);
        private void BackProc()
        {
            Messenger.Default.Send(new NotificationMessage(nameof(SessionsView_ViewModel)));
            Messenger.Default.Send(new LoadSessionsViewMessage(){Course = SelectedSession.Course});
        }
    }
}
