using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using TEC_App.Models;

namespace TEC_App.Helpers
{
	public class TestCases
	{
		[Test]
		public void AddCandidate(Candidate candidate)
		{
			throw new NotImplementedException();
		}

		[Test]
		public void GetCandidatesTest()
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

		
	}
}
