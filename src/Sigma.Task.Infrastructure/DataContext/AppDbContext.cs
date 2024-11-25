using Microsoft.EntityFrameworkCore;
using Sigma.Task.Core.Entities;

namespace Sigma.Task.Infrastructure.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; } = null!;
    }
}
