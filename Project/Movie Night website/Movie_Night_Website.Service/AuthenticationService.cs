using Movie_Night_Website.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Night_Website.Service
{
    public class AuthenticationService : IAuthentication
    {

        public string GenerateSalt()
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(13);
            return salt;
        }

        public string HashPassword(string userPassword, string salt)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(userPassword, salt);
            return hash;
        }

        public bool VerifyPassword(string userpassword, string hashedpassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(userpassword, hashedpassword);
        }
    }
}
