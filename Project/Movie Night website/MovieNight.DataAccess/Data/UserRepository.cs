using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Movie_Night_website.Models;
using Movie_Night_Website.Domain.Interfaces;

namespace Movie_Night_Website.DataAccess.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;
   
        public UserRepository (IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("LaptopConnection");
        }

        public void AddUser(string username, string hashpassword, string salt)
        {
            string query = "Insert into Users (Username, HashedPassword, Salt) Values (@Username, @Password, @Salt) ";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Username", username);
                sqlCommand.Parameters.AddWithValue("@Password", hashpassword);
                sqlCommand.Parameters.AddWithValue("@Salt", salt);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public User GetUser(string username)
        {
            User fetchedUser = null;
            string query = "Select Id, Username, HashedPassword, Salt, Role from Users where Username = @username";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@username", username);

                using SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string dbusername = reader.GetString(1);
                    string dbhashpassword = reader.GetString(2);
                    string salt = reader.GetString(3);
                    string dbrole = reader.GetString(4);

                    fetchedUser = new User(Id, dbusername, dbhashpassword, Enum.Parse<Role>(dbrole));


                }
                return fetchedUser;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
