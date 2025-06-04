using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie_Night_Website.Domain.Interfaces;
using BCrypt.Net;
using Movie_Night_website.Models;
using System.Net;


namespace Movie_Night_Website.Service
{
    public class UserService 
    {
        private readonly IUserRepository _userRepo;
        private readonly IAuthentication _auth;

        public UserService(IUserRepository userRepo, IAuthentication auth)
        {
            _userRepo = userRepo;
            _auth = auth;
        }


        public User Login(string username, string plainpassword)
        {
            var user = _userRepo.GetUser(username);
            if (user == null)
            {
                return null;
            }

            bool verified = _auth.VerifyPassword(plainpassword, user.Password);

            if (!verified)
            {
                return null;
            }
            else
            {
                return user;
            }

        }

        public void RegisterUser(string username, string password)
        {
            string salt = _auth.GenerateSalt();
            string hashedPassword = _auth.HashPassword(password, salt);
            
            _userRepo.AddUser(username, hashedPassword, salt);
        }
    }
}
