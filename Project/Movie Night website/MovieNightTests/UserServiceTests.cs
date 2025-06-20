using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Movie_Night_website.Models;
using Movie_Night_Website.Domain.Interfaces;
using Movie_Night_Website.Service;
using MovieNightTests.FakeData;

namespace MovieNightTests
{
    public class UserServiceTests
    {
        private readonly IUserRepository _fakeUserRepo = new FakeUserRepo();
        private readonly Mock<IAuthentication> _fakeAuth = new();
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _userService = new UserService(_fakeUserRepo, _fakeAuth.Object);
        }
        [Fact]
        public void LoginUser_ReturnsUser_Userfound()
        {
            //Arrange
            string username = "username";
            string password = "password";
            string salt = "pepperbruh";
            string hashedpassword = "hashedpassword";
            _fakeUserRepo.AddUser(username, hashedpassword, salt);
            _fakeAuth.Setup(auth => auth.VerifyPassword(password, hashedpassword)).Returns(true);


            //Act
            User result = _userService.Login(username, password);

            //Assert
            Assert.Equal(username, result.Username);

        }
        [Fact]
        public void LoginUser_ReturnsNull_UserNotfound()
        {
            //Arrange
            string username = "username";
            string password = "password";
            string salt = "pepperbruh";
            string hashedpassword = "hashedpassword";
       


            //Act
            User result = _userService.Login(username, password);

            //Assert
            Assert.Null(result);

        }
        [Fact]
        public void LoginUser_ReturnsNull_UserNotVerified()
        {
            //Arrange
            string username = "username";
            string password = "password";
            string salt = "pepperbruh";
            string hashedpassword = "hashedpassword";
            _fakeUserRepo.AddUser(username, hashedpassword, salt);
            _fakeAuth.Setup(auth => auth.VerifyPassword(password, hashedpassword)).Returns(false);


            //Act
            User result = _userService.Login(username, password);

            //Assert
            Assert.Null(result);

        }
    }
}
