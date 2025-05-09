
using System.Data.SqlClient;      //Use the data layer thing
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using Movie_Night_website.Models;

namespace Movie_Night_website.Data

{
    public class MovieNightDatabase
    {
        private string connectionString;

        public MovieNightDatabase(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("HomeConnection");
        }

        public void AddMediaToDB(string title, string trailerURL, string mediatype)
        {
            string query = $"Insert into Media (Title, TrailerURL, MediaType) Values (@Title, @TrailerURL, @MediaType)";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();    
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Title", title);
                sqlCommand.Parameters.AddWithValue("@TrailerURL", trailerURL);
                sqlCommand.Parameters.AddWithValue("@MediaType", mediatype);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
            }
        

            sqlConnection.Close();


        }

        public void AddUser(string username, string hashpassword)
        {
            string query = "Insert into Users (Username, Password) Values (@Username, @Password) ";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Username", username);
                sqlCommand.Parameters.AddWithValue("@Password", hashpassword);
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

        public User GetUser (string username, string hashpassword)
        {

            User fetchedUser = null;
            string query = "Select Username, Password from Users where Username = @username";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
         
            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Username", username);

                using SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows) 
                {
                    while (reader.Read())
                    {
                        int Id = reader.GetInt32(0);
                        string dbusername = reader.GetString(1);
                        string dbhashpassword = reader.GetString(2);
                        bool comparison = BCrypt.Net.BCrypt.EnhancedVerify(dbhashpassword, hashpassword); // take the S from SOLID and change this

                        if (comparison)
                        {
                            fetchedUser = new User(Id, dbusername, dbhashpassword, Role.Regular);
                            return fetchedUser;
                        }
                     
                    }
                }
                return null;
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
