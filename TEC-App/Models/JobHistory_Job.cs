namespace TEC_App.Models
{
	public class JobHistory_Job
	{
		public int Id { get; set; }
		public int JobHistoryId { get; set; }
		public JobHistory JobHistory { get; set; }

		public int JobId { get; set; }
		public Job Job { get; set; }

	}
}