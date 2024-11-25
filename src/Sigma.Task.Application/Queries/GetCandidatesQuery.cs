using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using Sigma.Task.Application.DTOs;
using Sigma.Task.Core.Entities;
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
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    PhoneNumber = candidate.PhoneNumber,
                    Email = candidate.Email,
                    CallSchedule = candidate.CallSchedule,
                    LinkedInProfile = candidate.LinkedInProfile,
                    GitHubProfile = candidate.GitHubProfile,
                    Comment = candidate.Comment
                });
            }
            return candidateDTOs;
        }
    }
}
