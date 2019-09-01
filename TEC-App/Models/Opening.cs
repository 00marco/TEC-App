using System;

namespace TEC_App.Models
{
	public class Opening
	{
		public int Id { get; set; }
		public int CompanyId { get; set; }
		public int RequiredQualificationId { get; set; }
		public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }
		public float HourlyPay { get; set; }
	}

}