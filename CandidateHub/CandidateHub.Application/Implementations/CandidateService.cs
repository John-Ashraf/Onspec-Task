using CandidateHub.Application.Abstracts;
using CandidateHub.Domain.Models.Entities;
using CandidateHub.Domain.Models.Exceptions;
using CandidateHub.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CandidateHub.Application.Implementations
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<int> AddCandidateAsync(Candidate candidate)
        {
            if (await _candidateRepository.GetTableNoTracking().Where(x => x.Email == candidate.Email).SingleOrDefaultAsync() != null)
            {
                throw new ConflictException("Candidate Is exist before");
            }
            var cand = await _candidateRepository.AddAsync(candidate);
            return cand.Id;
        }

        public async Task DeleteCandidate(int id)
        {
            var Candidate = await _candidateRepository.GetByIdAsync(id);
            if (Candidate == null)
            {
                throw new NotFoundException("This Candidate is Not Exist");
            }
            await _candidateRepository.DeleteAsync(Candidate);
        }

        public async Task<List<Candidate>> GetAllCandidatesAsync()
        {
            return await _candidateRepository.GetTableNoTracking().ToListAsync();
        }

        public async Task<Candidate> GetCandidateByEmail(string Email)
        {

            Candidate candidate = await _candidateRepository.GetTableNoTracking().Where(x => x.Email.Equals(Email)).SingleOrDefaultAsync();
            if (candidate == null)
            {
                throw new NotFoundException($"Could not find {Email}");
            }
            return candidate;
        }

        public async Task<Candidate> GetCandidateById(int id)
        {

            var candidate = await _candidateRepository.GetTableNoTracking().Where(x => x.Id == id).SingleOrDefaultAsync();
            if (candidate == null)
            {
                throw new NotFoundException($"Could not find {id}");
            }
            return candidate;
        }

        public async Task<int> UpdateCandidateAsync(Candidate candidate)
        {
            try
            {
                await _candidateRepository.UpdateAsync(candidate);
                return candidate.Id;
            }
            catch (ConflictException ex)
            {
                throw new ConflictException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
