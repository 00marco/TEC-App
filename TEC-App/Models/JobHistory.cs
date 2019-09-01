using System;

namespace TEC_App.Models
{
	public class JobHistory
	{
		public int Id { get; set; }
		public int CandidateId { get; set; }
		public int JobId { get; set; }
		public int CompanyId { get; set; }
		public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }
	}
}