using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie_Night_website.Models;

namespace Movie_Night_Website.Domain.Interfaces
{
    internal interface IAuthentication
    {
        User Login (string username, string password);
        bool VerifyPassword(string userpassword, string hashedpassword);
    }
}
