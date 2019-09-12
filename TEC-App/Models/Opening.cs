﻿using System;
using System.Collections.Generic;

namespace TEC_App.Models
{
	public class Opening
	{
		public int Id { get; set; }
		public DateTime DateTimeStart { get; set; }
		public DateTime DateTimeEnd { get; set; }
		public float HourlyPay { get; set; }


		public int CompanyId { get; set; }
		public Company Company { get; set; }


		public int RequiredQualificationId { get; set; }
		public Qualification RequiredQualification { get; set; }


		public int JobId { get; set; }
		public Job Job { get; set; }

	}

}