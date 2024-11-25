using MediatR;

using Sigma.Task.Application.DTOs;
using Sigma.Task.Core.Interfaces;

namespace Sigma.Task.Application.Queries
{
    public class GetCandidatesQuery : IRequest<IEnumerable<CandidateDTO>>
    {
    }

    public class GetCandidatesQueryHandler : IRequestHandler<GetCandidatesQuery, IEnumerable<CandidateDTO>>
    {
        private readonly ICandidateRepository _candidateRepository;

        public GetCandidatesQueryHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public async Task<IEnumerable<CandidateDTO>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
        {
            var candidates = await _candidateRepository.GetCandidatesAsync();
            List<CandidateDTO> candidateDTOs = new List<CandidateDTO>();
            foreach (var candidate in candidates)
            {
                candidateDTOs.Add(new CandidateDTO
                {
                    Id = candidate.Id,
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    PhoneNumber = candidate.PhoneNumber,
                    Email = candidate.Email,
                    CallSchedule = candidate.CallSchedule,
                    LinkedInProfile = candidate.LinkedInProfile,
                    GitHubProfile = candidate.GitHubProfile,
                    Comment = candidate.Comment,
                    CreatedDate = candidate.CreatedDate,
                    LastUpdatedDate = candidate.LastUpdatedDate
                });
            }
            return candidateDTOs;
        }
    }
}
