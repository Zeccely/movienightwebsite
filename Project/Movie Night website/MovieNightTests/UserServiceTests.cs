using Moq;
using Movie_Night_Website;
using Movie_Night_Website.Domain.Interfaces;
namespace MovieNightTests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly Mock<IAuthentication> _authMock;

        public UserServiceTests() 
        {
            
        }

        [Fact]
        public void Test1()
        {


        }
    }
}
