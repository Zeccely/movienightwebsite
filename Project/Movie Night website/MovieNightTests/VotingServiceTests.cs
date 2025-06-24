using Microsoft.SqlServer.Server;
using Moq;
using Movie_Night_website.Services;
using Movie_Night_Website;
using Movie_Night_Website.Domain.Interfaces;
namespace MovieNightTests
{
    public class VotingServiceTests
    {
        private readonly Mock<IMediaRepository> _medRepoMock = new();
        private readonly Mock<IMediaVoteRepository> _medVoteRepoMock = new();
        private VotingService _service;
        

        public VotingServiceTests()
        {
            _service = new VotingService(_medVoteRepoMock.Object, _medRepoMock.Object);
        }

        [Fact]
        public void CalculateFinalVerdict_ReturnsNothing_SetsValuetoTrue()
        {
            //Arrange

            _medVoteRepoMock.Setup(repo => repo.GetPositiveVotes(3)).Returns(7);
            _medVoteRepoMock.Setup(repo => repo.GetNegativeVotes(3)).Returns(6);

            //Act

            _service.EvaluateVotes(3);

            //Assert
            _medVoteRepoMock.Verify(result => result.UpdateFinalVerdict(3, true), Times.Once()); //accepted media

        }

        [Fact]
        public void CalculateFinalVerdict_ReturnsNothing_SetsValuetoFalse()
        {
            //Arrange
            
            _medVoteRepoMock.Setup(repo => repo.GetPositiveVotes(2)).Returns(8);
            _medVoteRepoMock.Setup(repo => repo.GetNegativeVotes(2)).Returns(16);

            //Act

            _service.EvaluateVotes(2);

            //Assert
            _medVoteRepoMock.Verify(result => result.UpdateFinalVerdict(2, false), Times.Once()); //rejected media

        }
        [Fact]
        public void CalculateFinalVerdict_ReturnsNothing_NotEnoughVotes() //did you know that 3 is not smaller than 3 so the test fails?
        {
            //Arrange
            
            _medVoteRepoMock.Setup(repo => repo.GetPositiveVotes(2)).Returns(1);
            _medVoteRepoMock.Setup(repo => repo.GetNegativeVotes(2)).Returns(2);

            //Act

            _service.EvaluateVotes(2);

            //Assert
            _medVoteRepoMock.Verify(repo => repo.UpdateFinalVerdict(It.IsAny<int>(), It.IsAny<bool>()), Times.Never()); //is not called at all

        }

        [Fact]
        public void CalculateFinalVerdict_ReturnsNothing_SameAmountOfPositiveAndNegative()
        {
            //Arrange
            
            _medVoteRepoMock.Setup(repo => repo.GetPositiveVotes(2)).Returns(2);
            _medVoteRepoMock.Setup(repo => repo.GetNegativeVotes(2)).Returns(2);

            //Act

            _service.EvaluateVotes(2);

            //Assert
            _medVoteRepoMock.Verify(repo => repo.UpdateFinalVerdict(It.IsAny<int>(), It.IsAny<bool>()), Times.Never()); //is not called at all

        }

        [Fact]
        public void CastVote_ReturnsNothing_UserSubmittedMedia()
        {
            //Arrange
            _medRepoMock.Setup(repo => repo.DidUserSubmitMedia(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            //Act
            _service.CastVote(1, 1, true);

            //Assert
            _medVoteRepoMock.Verify(repo => repo.CastVote(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Never);
        }
        [Fact]
        public void CastVote_ReturnsNothing_UserDidNotSubmitMedia()
        {
            //Arrange
            _medRepoMock.Setup(repo => repo.DidUserSubmitMedia(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
            _medVoteRepoMock.Setup(repo => repo.CastVote(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>()));

            //Act
            _service.CastVote(1, 1, true);

            //Assert
            _medVoteRepoMock.Verify(repo => repo.CastVote(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<bool>()), Times.Once);
        }
    }
}
