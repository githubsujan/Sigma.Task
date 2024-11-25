using Sigma.Task.Core.Entities;
using Sigma.Task.Core.Interfaces;
using Sigma.Task.Infrastructure.Cache;

namespace Sigma.Task.Infrastructure.Repositories
{
    public class CacheRepository : ICandidateRepository
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly CandidateCache _candidateCache;

        private string cacheKey = "candidates";
        public CacheRepository(ICandidateRepository candidateRepository, CandidateCache candidateCache)
        {
            _candidateRepository = candidateRepository;
            _candidateCache = candidateCache;
        }

        public async Task<Candidate?> GetCandidateByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesAsync()
        {
            if(!_candidateCache.TryGetValue(cacheKey, out var candidates))
            {
                candidates = await _candidateRepository.GetCandidatesAsync();
                _candidateCache.CreateEntry(cacheKey, candidates);
            }
            return candidates;
        }

        public async Task<Candidate> SaveCandidateAsync(Candidate entity)
        {
            _candidateCache.Remove(cacheKey);
            return await _candidateRepository.SaveCandidateAsync(entity);
        }
    }
}
