using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TEC_App.Models.DTO;
using TEC_App.ViewModels;

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
		    MessageBox.Show(CandidateWithQualificationsDto.CandidateName);
	    }
    }
}
