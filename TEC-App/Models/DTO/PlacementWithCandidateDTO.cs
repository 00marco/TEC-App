using System;

namespace TEC_App.Models.DTO
{
	public class PlacementWithCandidateDTO
	{
		public string CandidateName { get; set; }
		public string CompanyName { get; set; }
        public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }
		public float HoursWorked { get; set; }
		public float Payment { get; set; }

	}
}