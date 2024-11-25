using MediatR;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Sigma.Task.API.Controllers;
using Sigma.Task.Application.Commands;
using Sigma.Task.Application.DTOs;
using Sigma.Task.Application.Queries;

namespace Sigma.Task.API.UnitTests
{
    public class CandidateControllerTest
    {
        private Mock<ISender>? _mockSender;
        private CandidateController _controller;

        public CandidateControllerTest()
        {
            _mockSender = new Mock<ISender>();
            _controller = new CandidateController(_mockSender.Object);
        }

        [Fact]
        public async void GetCandidatesAsync_ReturnsOkResult()
        {
            IEnumerable<CandidateDTO> candidateDTOs = new List<CandidateDTO>()
            {
                new CandidateDTO
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
                    CreatedDate = DateTime.UtcNow
                }
            };
            var m = _mockSender.Setup(sender => sender.Send(It.IsAny<GetCandidatesQuery>(), new CancellationToken()))
                .ReturnsAsync(candidateDTOs);

            var result = await _controller.GetCandidatesAsync();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void SaveCandidate_ReturnsOkResult()
        {
            CandidateDTO candidateDTO = new CandidateDTO
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
                CreatedDate = DateTime.UtcNow
            };
            _mockSender.Setup(sender => sender.Send(It.IsAny<SaveCandidateCommand>(), new CancellationToken()))
                .ReturnsAsync(candidateDTO);

            var result = await _controller.SaveCandidateAysnc(candidateDTO);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
