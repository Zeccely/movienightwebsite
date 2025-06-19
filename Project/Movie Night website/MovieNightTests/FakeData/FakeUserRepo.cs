using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Movie_Night_website.Models;
using Movie_Night_Website.Domain.Interfaces;
using static System.Random;

namespace MovieNightTests.FakeData
{
    public class FakeUserRepo : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public void AddUser(string username, string hashpassword, string salt)
        {
            int Id = _users.Count + 1;
            User user = new User(Id, username, hashpassword, Role.Regular);
            _users.Add(user);
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username)
        {
            foreach (User user in _users)
            {
                if (user.Username == username) 
                {  
                    return user; 
                }
            }
            return null;  
        }

        public User GetUserById(int id)
        {
            foreach (User user in _users)
            {
                if (user.UserID == id)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
