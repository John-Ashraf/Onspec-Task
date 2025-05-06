using CandidateHub.Domain.Models.Entities;

namespace CandidateHub.Application.Abstracts
{
    public interface ICandidateService
    {
        Task<int> AddCandidateAsync(Candidate candidate);
        Task<int> UpdateCandidateAsync(Candidate candidate);
        Task<Candidate> GetCandidateById(int id);
        Task<Candidate> GetCandidateByEmail(string Email);
        Task DeleteCandidate(int id);
        Task<List<Candidate>> GetAllCandidatesAsync();


    }
}
