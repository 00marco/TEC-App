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

		public ICollection<Address_Location> Address_Location_Pairs { get; set; }
		public ICollection<Address_Candidate> Address_Candidate_Pairs { get; set; }

	}
}
