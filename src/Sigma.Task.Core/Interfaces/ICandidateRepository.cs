using Sigma.Task.Core.Entities;

namespace Sigma.Task.Core.Interfaces
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetCandidatesAsync();
        Task<Candidate?> GetCandidateByEmailAsync(string email);
        Task<Candidate> SaveCandidateAsync(Candidate entity);
    }
}
