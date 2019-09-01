using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEC_App.Models
{
	public class QualifiedCandidates
	{
		//TODO rename confusing name - prob rename to QualifiedCandidatesForOpening idk
		public int Id { get; set; }


		public int CandidateId { get; set; }
		public Candidate Candidate { get; set; }


		public int OpeningId { get; set; }
		public Opening Opening { get; set; }
		
	}
}
