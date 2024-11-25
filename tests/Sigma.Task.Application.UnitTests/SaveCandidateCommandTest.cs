using Moq;

using Sigma.Task.Application.Commands;
using Sigma.Task.Application.DTOs;
using Sigma.Task.Core.Entities;
using Sigma.Task.Core.Interfaces;

namespace Sigma.Task.Application.UnitTests
{
    public class SaveCandidateCommandTest
    {
        [Fact]
        public async void SaveCandidateCommandHandler_ReturnsSavedCandidate()
        {
            var mockCandidateRepository = new Mock<ICandidateRepository>();
            var saveCandidateCommandHandler = new SaveCandidateCommandHandler(mockCandidateRepository.Object);
            var candidate = new Candidate
            {
                Id = Guid.NewGuid(),
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                PhoneNumber = "+9779867566756",
                Email = "test@mail.com",
                CallSchedule = new DateTime(2024, 11, 25, 3, 15, 0).ToUniversalTime(),
                LinkedInProfile = "https://www.linkedin.com/in/test-a50141a4/",
                GitHubProfile = "https://github.com/githubtest",
                Comment = "test comment",
                CreatedDate = DateTime.UtcNow,
                LastUpdatedDate = null
            };
            var candidateDTO = new CandidateDTO
            {
                Id = Guid.NewGuid(),
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                PhoneNumber = "+9779867566756",
                Email = "test@mail.com",
                CallSchedule = new DateTime(2024, 11, 25, 3, 15, 0).ToUniversalTime(),
                LinkedInProfile = "https://www.linkedin.com/in/test-a50141a4/",
                GitHubProfile = "https://github.com/githubtest",
                Comment = "test comment",
                CreatedDate = DateTime.UtcNow,
                LastUpdatedDate = null
            };
            mockCandidateRepository.Setup(repo => repo.SaveCandidateAsync(It.IsAny<Candidate>())).ReturnsAsync(candidate);

            var result = await saveCandidateCommandHandler.Handle(new SaveCandidateCommand(candidateDTO), new CancellationToken());

            Assert.NotNull(result);
            Assert.Equal(candidateDTO.Email, candidate.Email);
        }
    }
}
