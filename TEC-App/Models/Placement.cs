namespace TEC_App.Models
{
	public class Placement
	{
		public int Id { get; set; }
		public int OpeningId { get; set; }
		public Opening Opening { get; set; }
		public int CandidateId { get; set; }
		public Candidate Candidate { get; set; }

	}
}