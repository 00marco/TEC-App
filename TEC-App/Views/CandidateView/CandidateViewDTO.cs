﻿using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using TEC_App.Messages;
using TEC_App.Models.Db;
using TEC_App.Views.IndividualCandidateDetailsView;

namespace TEC_App.Views.CandidateView
{
    public class CandidateViewDTO 
    {
	    public CandidateViewDTO()
	    {
	    }
	    public Candidate Candidate { get; set; }
	    public ICommand GotoCandidateDetailsCommand => new RelayCommand(GotoCandidateDetails);

	    private void GotoCandidateDetails()
	    {
			Messenger.Default.Send<NotificationMessage>(new NotificationMessage(nameof(IndividualCandidateDetailsView_ViewModel)));
			Messenger.Default.Send<ViewCandidateDetailsMessage>(new ViewCandidateDetailsMessage(){CandidateId = Candidate.Id});
	    }
    }
}
