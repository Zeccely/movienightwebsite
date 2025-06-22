using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Movie_Night_website.Models;
using Movie_Night_Website.Domain.Interfaces;

namespace Movie_Night_Website.DataAccess.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;
        private readonly ILogger<UserRepository> logger;

        public UserRepository(ILogger<UserRepository> logger ,IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Deployed");
            this.logger = logger;
            logger.LogInformation("Repo created");
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
                logger.LogError(ex.Message);
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
                logger.LogError($"Database error: {ex.Message}");
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public User GetUserById(int Id)
        {
            User fetchedUser = null;
            string query = "Select Id, Username, HashedPassword, Salt, Role from Users where Id = @Id";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", Id);

                using SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {

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
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<User> GetAllUsers()
        {
            List<User>fetchedUsers = new();
            string query = "Select Id, Username, Role from Users";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                using SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    User fetchedUser = null;
                    int Id = reader.GetInt32(0);
                    string dbusername = reader.GetString(1);
                    string dbrole = reader.GetString(2);

                    fetchedUser = new User(Id, dbusername, Enum.Parse<Role>(dbrole));
                    fetchedUsers.Add(fetchedUser);


                }
                return fetchedUsers;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
