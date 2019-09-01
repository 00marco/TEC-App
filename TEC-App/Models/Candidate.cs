using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEC_App.Models
{
	public class Candidate
	{
		public int Id { get; set; }
		public int NameId { get; set; }
		public Name Name { get; set; }
		public int AddressId { get; set; }
		public Address Address { get; set; }
	}
}
