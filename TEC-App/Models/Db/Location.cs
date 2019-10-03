using System.Collections.Generic;

namespace TEC_App.Models.Db
{
	public class Location
	{
		public int Id { get; set; }
		public int Capacity { get; set; }

		public int AddressId { get; set; }
		public Address Address { get; set; }
		//public ICollection<Address_Location> Address_Location_Pairs { get; set; }
		public ICollection<Session_Location> Session_Location_Pairs { get; set; }



	}
}
