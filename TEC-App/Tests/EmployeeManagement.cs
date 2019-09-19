using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
					.Include(d=>d.Addresses)
					.ThenInclude(d=>d.Address)
					.Include(d=>d.Candidate_Session_Pairs)
					.ThenInclude(d=>d.Session)
					.ThenInclude(d=>d.Session_Location_Pairs)
					.ThenInclude(d=>d.Location)
					//.ThenInclude(d=>d.Address_Location_Pairs)
					//.ThenInclude(d=>d.Address)
					.Include(d=>d.CandidateQualifications)
					.ThenInclude(d=>d.Qualification)
					.Include(d=>d.JobHistories)
					.ThenInclude(d=>d.JobHistory_Job_Pairs)
					.ThenInclude(d=>d.Job)
					.Include(d=>d.JobHistories)
					.ThenInclude(d=>d.JobHistory_Company_Pairs)
					.ThenInclude(d=>d.Company)
					.Include(d=>d.Placements)
					.ThenInclude(d=>d.Opening)
					.ThenInclude(d=>d.Company)
					.ToList();
				foreach (var v in list)
				{
					Console.WriteLine();
					Console.WriteLine($"{v.FirstName} {v.MiddleName} {v.LastName}");

					Console.WriteLine($"Addresses");
					var candidateAddresses = v.Addresses.Where(c => c.CandidateId == v.Id);
					if (candidateAddresses.Count() > 0)
					{
						foreach (var address in candidateAddresses)
						{
							Console.WriteLine($"\t{address.Address.ZipCode},{address.Address.Province},{address.Address.City},{address.Address.Street}");
						}
					}
					else
					{
						Console.WriteLine("\tNo addresses found");
					}

					Console.WriteLine("Sessions attended");
					var sessionsAttended = v.Candidate_Session_Pairs.Where(c => c.CandidateId == v.Id);
					if (sessionsAttended.Count() > 0)
					{
						foreach (var sessions in sessionsAttended)
						{
							Console.WriteLine($"\t{sessions.Session.Course.Name}-({sessions.Session.CourseId}) on {sessions.Session.DateTimeStart}");
						}
					}
					else
					{
						Console.WriteLine("\tNo sessions found");
					}

					Console.WriteLine("Candidate's Qualifications");
					var candidateQualifications = v.CandidateQualifications.Where(c => c.CandidateId == v.Id);
					if (candidateQualifications.Count() > 0)
					{
						foreach (var qualification in candidateQualifications)
						{
							Console.WriteLine($"\t{qualification.Qualification.Code}-{qualification.Qualification.Name}-({qualification.QualificationId})");
						}
					}
					else
					{
						Console.WriteLine("\tNo qualifications found");
					}

					Console.WriteLine("Job history");
					var jobHistory = v.JobHistories;
					if (jobHistory.Count() > 0)
					{

						foreach (var jobhistory in jobHistory)
						{
							Console.WriteLine(
								$"\t({jobhistory.Id})-{jobhistory.JobHistory_Job_Pairs.FirstOrDefault(c => c.JobHistory.Id == jobhistory.Id).Job.Name}" +
								$" at {jobhistory.JobHistory_Company_Pairs.FirstOrDefault(c=>c.JobHistoryId==jobhistory.Id).Company.Name}" +
								$" from {jobhistory.DateTimeStart} to {jobhistory.DateTimeEnd}");
						}
					}
					else
					{
						Console.WriteLine("\tNo job history found");
					}

					Console.WriteLine("Placements");
					var placements = v.Placements;
					if (placements.Count() > 0)
					{
						var printedPlacements = new List<Placement>();
						foreach (var placement in placements)
						{
							//there are multiple instances of the same placement which only differ in timestamp - this condition should ensure that printed placements are all unique
							if (printedPlacements.Where(c=>c.CandidateId==placement.CandidateId && c.OpeningId==placement.Id).Count()>0)
							{
								continue;
							}
							else
							{
								printedPlacements.Add(placement);
								Console.WriteLine($"\t{placement.Opening.Company.Name}");
							}
						}
					}
					else
					{
						Console.WriteLine("\tNo placements found");
					}

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
