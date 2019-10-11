using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using NUnit.Framework;
using TEC_App.Messages;
using TEC_App.Models.ViewDTO;
using TEC_App.Services.EmployeeService;

namespace TEC_App.ViewModels
{
    public class CandidateQualifiedForOpeningViewModel : ViewModelBase
    {
        public CandidateQualifiedForOpeningViewModel(ICandidateService candidateService)
        {
            CandidateService = candidateService;
            Messenger.Default.Register<ViewQualifiedCandidatesForOpeningViewMessage>(this, NotifyMe);
        }

        public ICandidateService CandidateService { get; set; }
        private void NotifyMe(ViewQualifiedCandidatesForOpeningViewMessage obj)
        {
            var candidates = CandidateService.GetCandidateWithQualificationsDtoList();
            var candidateDTO = new List<CandidatesQualifiedForOpeningDTO>();
            foreach (var v in candidates)
            {
                var newCandidateDTO = new CandidatesQualifiedForOpeningDTO(){CandidateWithQualificationsDto =  v};
                candidateDTO.Add(newCandidateDTO);
            }
            Candidates = new ObservableCollection<CandidatesQualifiedForOpeningDTO>(candidateDTO);
        }

        public ObservableCollection<CandidatesQualifiedForOpeningDTO> Candidates { get; set; } = new ObservableCollection<CandidatesQualifiedForOpeningDTO>();
        //TODO may want to use normal DTO instead of viewDTO since this candidate wont be needing buttons since i wont be putting a button per item
        //TODO cant add selecteditem until i finalize this
        public ICommand HireCandidateCommand => new RelayCommand(HireCandidate);
        public void HireCandidate()
        {
            throw new NotImplementedException();
        }

        public ICommand BackCommand => new RelayCommand(BackProc);

        private void BackProc()
        {
	        Messenger.Default.Send(new NotificationMessage(nameof(OpeningsView_ViewModel)));
        }
	}
}
