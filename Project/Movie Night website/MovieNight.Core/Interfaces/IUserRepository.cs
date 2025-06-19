using Movie_Night_website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Night_Website.Domain.Interfaces
{
    public interface IUserRepository //crud here
    { 
        void AddUser(string username, string hashpassword, string salt);
        User GetUser(string username);
        List<User> GetAllUsers();
        User GetUserById(int id);
    }
}
