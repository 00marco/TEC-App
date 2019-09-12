namespace TEC_App.Models
{
	public class Address_Location
	{
		public int Id { get; set; }
		public int AddressId { get; set; }
		public Address Address { get; set; }

		public int LocationId { get; set; }
		public Location Location { get; set; }

	}
}