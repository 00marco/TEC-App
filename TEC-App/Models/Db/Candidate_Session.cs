namespace TEC_App.Models.Db
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
