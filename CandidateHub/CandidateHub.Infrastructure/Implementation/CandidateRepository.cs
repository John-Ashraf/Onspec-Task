using CandidateHub.Domain.Models.Entities;
using CandidateHub.Infrastructure.Data;
using CandidateHub.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CandidateHub.Infrastructure.Implementation
{
    public class CandidateRepository : GenericRepoAsync<Candidate>, ICandidateRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Candidate> _Candidates;
        public CandidateRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _Candidates = context.Set<Candidate>();
        }

    }
}
