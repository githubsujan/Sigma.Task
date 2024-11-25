using Microsoft.EntityFrameworkCore;

using Sigma.Task.Core.Entities;
using Sigma.Task.Core.Interfaces;
using Sigma.Task.Infrastructure.DataContext;

namespace Sigma.Task.Infrastructure.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly AppDbContext _dbContext;

        public CandidateRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Candidate>> GetCandidatesAsync()
        {
            var candidates = await _dbContext.Candidates.ToListAsync();
            return candidates;
        }
        public async Task<Candidate?> GetCandidateByEmailAsync(string email)
        {
            var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(x => x.Email == email);
            return candidate;
        }
        public async Task<Candidate> SaveCandidateAsync(Candidate entity)
        {
            var candidate = await GetCandidateByEmailAsync(entity.Email);
            if(candidate is null)
            {
                entity.Id = Guid.NewGuid();
                entity.CreatedDate = DateTime.UtcNow;
                _dbContext.Candidates.Add(entity);
            }
            else
            {
                candidate.FirstName = entity.FirstName;
                candidate.LastName = entity.LastName;
                candidate.PhoneNumber = entity.PhoneNumber;
                candidate.Email = entity.Email;
                candidate.CallSchedule = entity.CallSchedule;
                candidate.LinkedInProfile = entity.LinkedInProfile;
                candidate.GitHubProfile = entity.GitHubProfile;
                candidate.Comment = entity.Comment;
                candidate.LastUpdatedDate = DateTime.UtcNow;
                _dbContext.Update(candidate);
            }
            _dbContext.SaveChanges();
            return candidate is null ? entity : candidate;
        }
    }
}
