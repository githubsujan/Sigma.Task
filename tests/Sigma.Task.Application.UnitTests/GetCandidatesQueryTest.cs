using Moq;

using Sigma.Task.Application.Queries;
using Sigma.Task.Core.Entities;
using Sigma.Task.Core.Interfaces;

namespace Sigma.Task.Application.UnitTests
{
    public class GetCandidatesQueryTest
    {
        [Fact]
        public async void GetCandidatesQueryHandler_ReturnsListOfCandidates()
        {
            var mockCandidateRepository = new Mock<ICandidateRepository>();
            var getCandidatesQueryHandler = new GetCandidatesQueryHandler(mockCandidateRepository.Object);
            IEnumerable<Candidate> candidates = new List<Candidate>()
            {
                new Candidate
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
                }
            };
            mockCandidateRepository.Setup(repo => repo.GetCandidatesAsync()).ReturnsAsync(candidates);

            var result = await getCandidatesQueryHandler.Handle(new GetCandidatesQuery(), new CancellationToken());

            Assert.NotNull(result);
            Assert.Collection(result,el => el.FirstName.Equals(candidates.First().FirstName));
        }
    }
}
