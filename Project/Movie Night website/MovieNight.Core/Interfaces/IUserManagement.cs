using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Night_Website.Domain.Interfaces
{
    public interface IUserManagement
    {
        void CreateUser (string username, string password);
        void GetUser (string username, string password);
        void DeleteUser (string username, string password);
        void UpdateUser (string username, string password);
    }
}
