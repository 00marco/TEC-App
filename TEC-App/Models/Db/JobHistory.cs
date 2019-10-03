using System;
using System.Collections.Generic;

namespace TEC_App.Models.Db
{
	public class JobHistory
	{
		public int Id { get; set; }
		public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }


		public int CandidateId { get; set; }
		public Candidate Candidate { get; set; }

		public ICollection<JobHistory_Company> JobHistory_Company_Pairs { get; set; }
		public ICollection<JobHistory_Job> JobHistory_Job_Pairs { get; set; }



		
	}
}