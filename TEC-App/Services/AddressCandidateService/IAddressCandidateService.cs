using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC_App.Models.Db;

namespace TEC_App.Services.AddressCandidateService
{
    public interface IAddressCandidateService
    {
        Address_Candidate Add(Address_Candidate addressCandidate);
        void Remove(int addressId, int candidateId);
        List<Address_Candidate> GetAllAddressCandidates();
        Address_Candidate GetFromAddressAndCandidateId(int addressId, int candidateId);
    }
}
