using System;

namespace TEC_App.Models.Db
{
	public class Placement
	{
		public int Id { get; set; }
		public DateTime Timestamp { get; set; }

		public int OpeningId { get; set; }
		public Opening Opening { get; set; }

		public int CandidateId { get; set; }
		public Candidate Candidate { get; set; }

		public int TotalHoursWorked { get; set; }


	}
}