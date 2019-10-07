using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace TEC_App.Models.DTO
{
	public class CompanyWithOpeningDetailsDTO
	{
		public string CompanyName { get; set; }
		public string OpeningName { get; set; }
		public string RequiredQualifications { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public float HourlyPay { get; set; }

       
    }
}