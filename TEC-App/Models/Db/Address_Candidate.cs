namespace TEC_App.Models.Db
{
	public class Address_Candidate
	{
		public int Id { get; set; }
		public int AddressId { get; set; }
		public Address Address { get; set; }
		public int CandidateId { get; set; }
		public Candidate Candidate { get; set; }
	}
}