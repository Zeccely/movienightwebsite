
using Microsoft.Data.SqlClient;      //Use the data layer thing
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using Movie_Night_website.Models;
using BCrypt.Net;
using Movie_Night_Website.Domain.Interfaces;
using System.Net.Mime;




namespace Movie_Night_Website.DataAccess.Data

{
    public class MediaRepository: IMediaRepository
    {
        private string connectionString;

        public MediaRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("LaptopConnection");
        }

        public bool CheckMediaType(string mediaTypeName)
        {
            string query = "Select Id From MediaTypes Where Name = @MediaTypeName"; // please check if the mediatype exists
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

        public int GetMediaTypeIDFromMovie(string movieName)
        {   
            string query = "Select MediaTypeId from Media m INNER JOIN MediaTypes mt ON m.MediaTypeId = mt.Id Where m.Title = @MovieName "; // select the mediatypeId for the movie I added pls
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

        public int GetMediaTypeID(string mediaTypeName)
        {
            string query = "Select Id from MediaTypes where Name = @MediaTypeName";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@MediaTypeName", mediaTypeName);
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
            string query = $"Insert into Media (Title, TrailerURL, MediaTypeId, UserId) Values (@Title, @TrailerURL, @MediaTypeID, @UserID)";
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

        public List<Media> GetAllMedia()
        {
            List<Media> allMedia = new List<Media>();
            string query = "Select * from Media";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                using SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int Id = reader.GetInt32(1);
                    int Submittedby = reader.GetInt32(2);
                    string Title = reader.GetString(3);
                    string TrailerURL = reader.GetString(4);
                    int MediaTypeId = reader.GetInt32(5);

                    Media NewMedia = new(Id, TrailerURL, Title, MediaTypeId, Submittedby);

                    allMedia.Add(NewMedia);

                }
                return allMedia;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
        }


    }
}
