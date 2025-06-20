using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Movie_Night_website.Services;
using Movie_Night_Website.Domain.Interfaces;

namespace MovieNightTests
{
    public class MediaServiceTests
    {
        private readonly MediaService _service;
        private readonly Mock<IMediaRepository> _fakeMedRepo = new();

        public MediaServiceTests()
        {
            _service = new MediaService(_fakeMedRepo.Object);
        }

        [Fact]
        public void AddMedia_ReturnsNothing_MediaTypeDoesNotExist()
        {
            //Arrange
            string title = "ladidadida";
            string trailer = "youtubelink";
            string mediatype = "movie";
            _fakeMedRepo.Setup(repo => repo.CheckMediaType(It.IsAny<string>())).Returns(false);
            _fakeMedRepo.Setup(repo => repo.AddMediaType(It.IsAny<string>()));
            _fakeMedRepo.Setup(repo => repo.GetMediaTypeID(It.IsAny<string>())).Returns(2);
            //_fakeMedRepo.Setup(repo => repo.AddMedia(It.IsAny<string>(), It.IsAny<string>(), 2, 4));

            //Act
            _service.AddMediaToDB(title, trailer, mediatype, 4);

            //Assert
            _fakeMedRepo.Verify(repo => repo.AddMedia(title,trailer, 2, 4), Times.Once());
        }
        [Fact]
        public void AddMedia_ReturnsNothing_MediaTypeAlreadyExists()
        {
            //Arrange
            string title = "ladidadida";
            string trailer = "youtubelink";
            string mediatype = "movie";
            _fakeMedRepo.Setup(repo => repo.CheckMediaType(It.IsAny<string>())).Returns(true);
            _fakeMedRepo.Setup(repo => repo.GetMediaTypeID(It.IsAny<string>())).Returns(2);
            //Act
            _service.AddMediaToDB(title, trailer, mediatype, 4);
            //Assert
            _fakeMedRepo.Verify(repo => repo.AddMedia(title, trailer, 2, 4), Times.Once());
        }

        //[Fact]
        //public void AddMedia_ThrowsException_WhenMediaTypeIsEmpty() was a nice try?
        //{
        //    // Arrange
        //    string title = "bla";
        //    string trailer = "bla.com";
        //    string emptyMediaType = "";
        //    int userId = 4;

        //    // Act
        //    _service.AddMediaToDB(title, trailer, emptyMediaType, userId));
        //    // Assert
        //    Assert.Equal("Media type cannot be empty", ex.Message);
        //}




    }
}
