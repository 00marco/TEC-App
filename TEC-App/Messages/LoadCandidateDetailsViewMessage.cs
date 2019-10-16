using TEC_App.Models.Db;

namespace TEC_App.Messages
{
    public class LoadCandidateDetailsViewMessage
    {
        public Candidate Candidate { get; set; }
    }
}