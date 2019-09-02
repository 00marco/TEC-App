using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEC_App.Models
{
	public class Address
	{
		public int Id { get; set; }
		public string ZipCode { get; set; }
		public string Province { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		//todo not sure
		//TODO Reference for reasoning why properties are made like this https://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx


		public Candidate Candidate { get; set; }
		public int CandidateId { get; set; }

		public Location Location { get; set; }
		public int LocationId { get; set; }

	}
}
