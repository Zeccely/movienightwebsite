
using Microsoft.Data.SqlClient;      //Use the data layer thing
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using Movie_Night_website.Models;
using BCrypt.Net;




namespace Movie_Night_Website.DataAccess.Data

{
    public class MovieNightDatabase
    {
        private string connectionString;

        public MovieNightDatabase(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("HomeConnection");
        }

        public void AddMediaToDB(string title, string trailerURL, int mediatypeID, int userID)
        {
            string query = $"Insert into Media (Title, TrailerURL, MediaTypeID, UserID) Values (@Title, @TrailerURL, @MediaTypeID, UserID)";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Title", title);
                sqlCommand.Parameters.AddWithValue("@TrailerURL", trailerURL);
                sqlCommand.Parameters.AddWithValue("@MediaTypeID", mediatypeID);
                sqlCommand.Parameters.AddWithValue("@UserID", userID);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
            }


            sqlConnection.Close();


        }
        public void AddUser(string username, string hashpassword, string salt)
        {
            string query = "Insert into Users (Username, Password, Salt) Values (@Username, @Password, @Salt) ";
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

        public User GetUser(string username, string hashpassword)
        {

            User fetchedUser = null;
            string query = "Select Username, Password from Users where Username = @username";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@username", username);

                using SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int Id = reader.GetInt32(0);
                        string dbusername = reader.GetString(1);
                        string dbhashpassword = reader.GetString(2);
                        string dbsalt = reader.GetString(3);

                        fetchedUser = new User(Id, dbusername, dbhashpassword, Role.Regular);
                    }
                    return fetchedUser;
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
