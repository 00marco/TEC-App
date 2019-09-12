namespace TEC_App.Models
{
	public class Session_Location
	{
		public int Id { get; set; }
		public int SessionId { get; set; }
		public Session Session { get; set; }

		public int LocationId { get; set; }
		public Location Location { get; set; }
	}
}