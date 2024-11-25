using MediatR;

using Sigma.Task.Application.DTOs;
using Sigma.Task.Core.Entities;
using Sigma.Task.Core.Interfaces;

namespace Sigma.Task.Application.Commands
{
    public class SaveCandidateCommand : IRequest<CandidateDTO>
    {
        public readonly CandidateDTO CandidateDTO;
        public SaveCandidateCommand(CandidateDTO candidateDTO)
        {
            CandidateDTO = candidateDTO;
        }
    }

    public class SaveCandidateCommandHandler : IRequestHandler<SaveCandidateCommand, CandidateDTO>
    {
        private readonly ICandidateRepository _candidateRepository;

        public SaveCandidateCommandHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<CandidateDTO> Handle(SaveCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = new Candidate
            {
                FirstName = request.CandidateDTO.FirstName,
                LastName = request.CandidateDTO.LastName,
                PhoneNumber = request.CandidateDTO.PhoneNumber,
                Email = request.CandidateDTO.Email,
                CallSchedule = request.CandidateDTO.CallSchedule,
                LinkedInProfile = request.CandidateDTO.LinkedInProfile,
                GitHubProfile = request.CandidateDTO.GitHubProfile,
                Comment = request.CandidateDTO.Comment
            };
            var savedCandidate = await _candidateRepository.SaveCandidateAsync(candidate);
            request.CandidateDTO.Id = savedCandidate.Id;
            request.CandidateDTO.CreatedDate = savedCandidate.CreatedDate;
            request.CandidateDTO.LastUpdatedDate = savedCandidate.LastUpdatedDate;
            return request.CandidateDTO;
        }
    }
}
