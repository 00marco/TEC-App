using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEC_App.Models.Db
{
	public class Candidate
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		[NotMapped]
		public string FullName => $"{FirstName} {MiddleName} {LastName}";
		public DateTime Timestamp { get; set; }


		public ICollection<Address_Candidate> Addresses { get; set; }
		public ICollection<JobHistory> JobHistories { get; set; }
		public ICollection<Placement> Placements { get; set; }
		public ICollection<Candidate_Qualification> CandidateQualifications { get; set; }
		public ICollection<Candidate_Session> Candidate_Session_Pairs { get; set; }
	}
}
