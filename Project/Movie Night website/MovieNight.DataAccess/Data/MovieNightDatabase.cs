
using Microsoft.Data.SqlClient;      //Use the data layer thing
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using Movie_Night_website.Models;
using BCrypt.Net;
using Movie_Night_Website.Domain.Interfaces;
using System.Net.Mime;




namespace Movie_Night_Website.DataAccess.Data

{
    public class MovieNightDatabase: IUserRepository , IMediaRepository
    {
        private string connectionString;

        public MovieNightDatabase(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("LaptopConnection");
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

        public User GetUser(string username)
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
                if (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string dbusername = reader.GetString(1);
                    string dbhashpassword = reader.GetString(2);
                    string dbsalt = reader.GetString(3);
                    Role dbrole = (Role)Enum.Parse(typeof(Role), dbusername);

                    return fetchedUser = new User(Id, dbusername, dbhashpassword, dbrole);
                    
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
        public bool CheckMediaType(string mediaTypeName)
        {
            string query = "Select Id From MediaType Where Name = @MediaTypeName"; // please check if the mediatype exists
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@MediaTypeName", mediaTypeName);
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            finally
            {
                sqlConnection.Close(); 
            }

        }
        public void AddMediaType(string mediaTypeName)
        {
            bool check = CheckMediaType(mediaTypeName);
            string query = "Insert into MediaTypes (Name) Values (@Name) ";
            
            if (!check) //if mediatype check fails, add a mediatype
            {
                using SqlConnection sqlConnection = new SqlConnection(connectionString);
                try
                {
                    sqlConnection.Open();
                    using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Name", mediaTypeName);
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

        }

        public int GetMediaTypeID(string movieName)
        {   
            string query = "Select MediaTypeId from Media m INNER JOIN MediaType mt ON m.MediaTypeId = mt.Id Where m.Title = @MovieName "; // select the mediatypeId for the movie I added pls
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@MovieName", movieName);
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                { 
                   return reader.GetInt32(0);

                }
                else
                {
                    return 0;
                }

            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void AddMedia(string title, string trailerURL, int mediatypeID, int userID)
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


    }
}
