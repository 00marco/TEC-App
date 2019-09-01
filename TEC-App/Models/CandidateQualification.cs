namespace TEC_App.Models
{
	public class CandidateQualification
	{
		public int Id { get; set; }
		public int CandidateId { get; set; }
		public Candidate Candidate { get; set; }
		public int QualificationId { get; set; }
		public Qualification Qualification { get; set; }
	}
}