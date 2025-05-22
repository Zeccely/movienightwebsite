using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie_Night_website.Models;

namespace Movie_Night_Website.Domain.Interfaces
{
    public interface IAuthentication
    {
        string GenerateSalt(string password);
        string HashPassword(string userPassword);
        bool VerifyPassword(string userpassword, string hashedpassword);
    }
}
