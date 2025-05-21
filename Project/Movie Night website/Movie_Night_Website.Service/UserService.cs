using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie_Night_Website.DataAccess.Data;


namespace Movie_Night_Website.Service
{
    public class UserService
    {
        private readonly MovieNightDatabase _database;

        public UserService(MovieNightDatabase database)
        {
            _database = database;
        }

        public bool VerifyPassword(string userPassword, string dbPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(userPassword, dbPassword);
        }
        public void CreateUser (string username, string password)
        {

        }
    }
}
