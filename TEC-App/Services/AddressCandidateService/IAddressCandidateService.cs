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
        Address_Candidate AddAddressToCandidate(Address_Candidate addressCandidate);
        void RemoveAddressFromCandidate(int addressId, int candidateId);
        void Soft_RemoveAddressFromCandidate(int addressId, int candidateId);
        List<Address_Candidate> GetAllAddressCandidatePairs();
        Address_Candidate GetPairFromAddressAndCandidateId(int addressId, int candidateId);
    }
}
