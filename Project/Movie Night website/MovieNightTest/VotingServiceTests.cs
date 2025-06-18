using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movie_Night_Website.Service

namespace MovieNightTest
{
    public class VotingServiceTests
    {
        private readonly VotingService _sut;
        private readonly Mock<IMediaRepository> _mediamock = new Mock<IMediaRepository>();
        private readonly Mock<IMediaVoteRepository> _votemock = new Mock<IMediaVoteRepository> ();

        public VotingServiceTests()
        {
            _sut = new VotingService(_mediamock.Object, _votemock.Object);
        }

        [Fact]
        public void CastVoteTest()
        {
            //Arrange
            int userId = 1;
            int movieId = 2;
            bool vote = true;

            //Act

            //Assert
            
        }
    }
}
