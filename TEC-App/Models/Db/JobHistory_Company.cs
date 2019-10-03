namespace TEC_App.Models.Db
{
	public class JobHistory_Company
	{
		public int Id { get; set; }
		public int JobHistoryId { get; set; }
		public JobHistory JobHistory { get; set; }
		public int CompanyId { get; set; }
		public Company Company { get; set; }
	}
}