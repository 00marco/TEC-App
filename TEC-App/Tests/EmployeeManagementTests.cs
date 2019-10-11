using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TEC_App.Helpers;
using TEC_App.Models;
using TEC_App.Models.Db;
using TEC_App.Services.EmployeeService;
using TEC_App.ViewModels;

namespace TEC_App.Tests
{
	public class EmployeeManagementTests
	{
        public EmployeeManagementTests()
        {
            TecAppContext = new TecAppContext();
            CandidateService = new CandidateService(TecAppContext);
        }
        public ICandidateService CandidateService { get; set; }

        public TecAppContext TecAppContext { get; set; }
        //[Test]

        #region Old tests used to initialize database
        public void AddQualifications()
        {
            #region 12 Qualifications

            var q1 = new Qualification()
            {
                Code = "SEC-45",
                Description = "Secretarial work, at least 45 words per minute",
            };
            var q2 = new Qualification()
            {
                Code = "SEC-60",
                Description = "Secretarial work, at least 60 words per minute",
            };

            var q3 = new Qualification()
            {
                Code = "CLERK",
                Description = "General clerking work",
            };
            var q4 = new Qualification()
            {
                Code = "PRG-VB",
                Description = "Programmer, Visual Basic",
            };

            var q5 = new Qualification()
            {
                Code = "PRG-C++",
                Description = "Programmer, C++",
            };
            var q6 = new Qualification()
            {
                Code = "DBA-ORA",
                Description = "Database Administrator, Oracle",
            };
            var q7 = new Qualification()
            {
                Code = "DBA-DB2",
                Description = "Database Administrator,IBMDB2",
            };

            var q8 = new Qualification()
            {
                Code = "DBA-SQLSERV",
                Description = "Database Administrator, MS SQL Server",
            };
            var q9 = new Qualification()
            {
                Code = "SYS-1",
                Description = "Systems Analyst, level 1",
            };
            var q10 = new Qualification()
            {
                Code = "SYS-2",
                Description = "Systems Analyst, level2",
            };

            var q11 = new Qualification()
            {
                Code = "NW-NOV",
                Description = "Network Administrator, Novell experience",
            };
            var q12 = new Qualification()
            {
                Code = "WD-CF",
                Description = "Web Developer, ColdFusion",
            };


            #endregion

            var qualifications = new List<Qualification>() { q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12 };
            using (var context = new TecAppContext())
            {
                foreach (var v in qualifications)
                {
                    context.Set<Qualification>().Add(v);
                    context.SaveChanges();
                }
            }
        }

        public void AddPlacementAndJobHistory()
        {
            #region 12 Qualifications

            var q1 = new Qualification()
            {
                Code = "SEC-45",
                Description = "Secretarial work, at least 45 words per minute",
            };
            var q2 = new Qualification()
            {
                Code = "SEC-60",
                Description = "Secretarial work, at least 60 words per minute",
            };

            var q3 = new Qualification()
            {
                Code = "CLERK",
                Description = "General clerking work",
            };
            var q4 = new Qualification()
            {
                Code = "PRG-VB",
                Description = "Programmer, Visual Basic",
            };

            var q5 = new Qualification()
            {
                Code = "PRG-C++",
                Description = "Programmer, C++",
            };
            var q6 = new Qualification()
            {
                Code = "DBA-ORA",
                Description = "Database Administrator, Oracle",
            };
            var q7 = new Qualification()
            {
                Code = "DBA-DB2",
                Description = "Database Administrator,IBMDB2",
            };

            var q8 = new Qualification()
            {
                Code = "DBA-SQLSERV",
                Description = "Database Administrator, MS SQL Server",
            };
            var q9 = new Qualification()
            {
                Code = "SYS-1",
                Description = "Systems Analyst, level 1",
            };
            var q10 = new Qualification()
            {
                Code = "SYS-2",
                Description = "Systems Analyst, level2",
            };

            var q11 = new Qualification()
            {
                Code = "NW-NOV",
                Description = "Network Administrator, Novell experience",
            };
            var q12 = new Qualification()
            {
                Code = "WD-CF",
                Description = "Web Developer, ColdFusion",
            };


            #endregion

            var qualifications = new List<Qualification>() { q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12 };
            using (var context = new TecAppContext())
            {
                foreach (var v in qualifications)
                {
                    context.Set<Qualification>().Add(v);
                    context.SaveChanges();
                }
            }
        }


        #endregion

        [Test]
        public void GetCandidateWithQualificationsDtoList()
        {
                var list = CandidateService.GetCandidateWithQualificationsDtoList();
                foreach (var v in list)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{v.ActualCandidateId}");
                    Console.WriteLine($"{v.Qualifications}");
                    Console.WriteLine($"{v.CandidateName}");
                    Console.WriteLine();
                }
        }

        [Test]
		public void GetCandidates()
		{
                var list = CandidateService.GetCandidateList();
				foreach (var v in list)
				{
					Console.WriteLine();
					Console.WriteLine($"{v.FirstName} {v.MiddleName} {v.LastName}");

					Console.WriteLine($"Addresses");
					var candidateAddresses = v.Addresses.Where(c => c.CandidateId == v.Id);
					if (candidateAddresses.Any())
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
					if (sessionsAttended.Any())
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
					if (candidateQualifications.Any())
					{
						foreach (var qualification in candidateQualifications)
						{
							Console.WriteLine($"\t{qualification.Qualification.Code}-({qualification.QualificationId})");
						}
					}
					else
					{
						Console.WriteLine("\tNo qualifications found");
					}

					Console.WriteLine("Job history");
					var jobHistory = v.JobHistories;
					if (jobHistory.Any())
					{

						foreach (var x in jobHistory)
						{
							var jobName = x.JobHistory_Job_Pairs.FirstOrDefault(c => c.JobHistory.Id == x.Id)?.Job.Name;
							var companyName = x.JobHistory_Company_Pairs.FirstOrDefault(c => c.JobHistoryId == x.Id)?.Company.Name;
							var start = x.DateTimeStart;
							var end = x.DateTimeEnd;
							Console.WriteLine($"\t{jobName} at {companyName} from {start} to {end}");
						}
					}
					else
					{
						Console.WriteLine("\tNo job history found");
					}

					Console.WriteLine("Placements");
					var placements = v.Placements;
					if (placements.Any())
					{
						var printedPlacements = new List<Placement>();
						foreach (var placement in placements)
						{
							//there are multiple instances of the same placement which only differ in timestamp - this condition should ensure that printed placements are all unique
							if (!printedPlacements.Any(c => c.CandidateId==placement.CandidateId && c.OpeningId==placement.Id))
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

		//[Test]
		public void UpdateCandidateDetails()
		{
			throw new NotImplementedException();
		}

		//[Test]
		public void RemoveCandidate()
		{
			throw new NotImplementedException();
		}
	}
}
