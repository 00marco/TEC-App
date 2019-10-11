using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.DTO;
using TEC_App.ViewModels;
using TEC_App.Views.IndividualCandidateDetailsView;

namespace TEC_App.Models.ViewDTO
{
    public class CandidateViewDTO 
    {
	    public CandidateViewDTO()
	    {
		    CandidateWithQualificationsDto = new CandidateWithQualificationsDTO();
	    }
	    public CandidateWithQualificationsDTO CandidateWithQualificationsDto { get; set; }
	    public ICommand GotoCandidateDetailsCommand => new RelayCommand(GotoCandidateDetails);

	    private void GotoCandidateDetails()
	    {
			Messenger.Default.Send<NotificationMessage>(new NotificationMessage(nameof(IndividualCandidateDetailsView_ViewModel)));
			Messenger.Default.Send<ViewCandidateDetailsMessage>(new ViewCandidateDetailsMessage(){CandidateId = CandidateWithQualificationsDto.ActualCandidateId});
	    }
    }
}
