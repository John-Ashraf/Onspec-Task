using CandidateHub.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CandidateHub.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Candidate> Candidates { get; set; }


    }
}
