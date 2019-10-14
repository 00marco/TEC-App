using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TEC_App.Models.Db
{
	public class Address
	{
		public int Id { get; set; }
		public string ZipCode { get; set; }
		public string Province { get; set; }
		public string City { get; set; }
		public string Street { get; set; }

        [NotMapped]
        public string FullAddress => $"{ZipCode}-{Province}, {City}, {Street}";


        //public ICollection<Address_Location> Address_Location_Pairs { get; set; }
        public ICollection<Address_Candidate> Address_Candidate_Pairs { get; set; }
		public ICollection<Location> Locations { get; set; }

	}
}
