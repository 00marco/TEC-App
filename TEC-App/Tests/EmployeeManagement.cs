using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models;

namespace TEC_App.Tests
{
	public class EmployeeManagement
	{
		[Test]
		public void AddCandidate(Candidate candidate)
		{
			throw new NotImplementedException();
		}

		[Test]
		public void GetCandidates()
		{
			using (var context = new TecAppContext())
			{
				//Movie movie = context.Set<Movie>().Find(movieId);
				//movie.Should().BeNull();

				var list = context.Set<Candidate>()
					.ToList();
				foreach (var v in list)
				{
					Console.WriteLine(v.FirstName);
				}
			}
		}

		[Test]
		public void UpdateCandidateDetails()
		{
			throw new NotImplementedException();
		}

		[Test]
		public void RemoveCandidate()
		{
			throw new NotImplementedException();
		}
	}
}
