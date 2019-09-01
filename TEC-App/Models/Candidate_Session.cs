using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEC_App.Models
{
	public class Candidate_Session
	{
		public int Id { get; set; }


		public int CandidateId { get; set; }
		public Candidate Candidate { get; set; }


		public int SessionId { get; set; }
		public Session Session { get; set; }
	}
}
