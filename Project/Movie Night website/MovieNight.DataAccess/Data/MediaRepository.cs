
using Microsoft.Data.SqlClient;      //Use the data layer thing
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using Movie_Night_website.Models;
using BCrypt.Net;
using Movie_Night_Website.Domain.Interfaces;
using System.Net.Mime;
using Microsoft.Extensions.Logging;




namespace Movie_Night_Website.DataAccess.Data

{
    public class MediaRepository : IMediaRepository
    {
        private string connectionString;
        private readonly ILogger<MediaRepository> logger;

        public MediaRepository(ILogger<MediaRepository> logger, IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("HomeConnection");
            this.logger = logger;
        }

        public bool CheckMediaType(string mediaTypeName) //should have refactored
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
            catch (Exception ex)
            {
                logger.LogError($"I return false because {ex.Message}");
                return false;
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
                    logger.LogError($"Nothing went into the DB because {ex.Message}");
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
                    logger.LogInformation("There is no Media type for this Media, returned 0");
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
                    logger.LogInformation("Media type does not exist yet, returned 0");
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
            string query = $"Insert into Media (Title, TrailerURL, MediaTypeId, UserId) Values (@Title, @TrailerURL, @MediaTypeID, @ContributorID)";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Title", title);
                sqlCommand.Parameters.AddWithValue("@TrailerURL", trailerURL);
                sqlCommand.Parameters.AddWithValue("@MediaTypeID", mediatypeID);
                sqlCommand.Parameters.AddWithValue("@ContributorID", userID);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                logger.LogError($"Media not added: {ex.Message}");
            }
            finally
            {
                sqlConnection.Close();
            }



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
                    int Id = reader.GetInt32(0);
                    int Submittedby = reader.GetInt32(1);
                    string Title = reader.GetString(2);
                    string TrailerURL = reader.GetString(3);
                    int MediaTypeId = reader.GetInt32(4);

                    Media NewMedia = new(Id, TrailerURL, Title, MediaTypeId, Submittedby);

                    allMedia.Add(NewMedia);

                }
                return allMedia;
            }
            catch (Exception ex)
            {
                logger.LogError($"I return null because {ex.Message}");
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public List<Media> GetApprovedMedia()
        {
            List<Media> votedMedia = new();
            string query = "Select * From Media Where FinalVerdict is not NULL";
            using SqlConnection sqlConnection = new(connectionString);
            try
            {
                sqlConnection.Open();
                using SqlCommand cmd = new(query, sqlConnection);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int contributorId = reader.GetInt32(1);
                    string title = reader.GetString(2);
                    string trailer = reader.GetString(3);
                    int mediaTypeId = reader.GetInt32(4);

                    votedMedia.Add(new Media(id, trailer, title, mediaTypeId, contributorId));
                }
                return votedMedia;
            }
            catch (Exception ex)
            {
                logger.LogError($"I return null because {ex.Message}");
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public List<Media> GetWatchedMedia()
        {
            List<Media> watchedMedia = new();

            string query = "Select Distinct m.* From Media m InnerJoin MovieNight mn on mn.MediaId = m.Id Where mn.DateOfEvent is not null";
            using SqlConnection sqlConnection = new(connectionString);
            try
            {
                sqlConnection.Open();
                using SqlCommand cmd = new(query, sqlConnection);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int contributorId = reader.GetInt32(1);
                    string title = reader.GetString(2);
                    string trailer = reader.GetString(3);
                    int mediaTypeId = reader.GetInt32(4);

                    watchedMedia.Add(new Media(id, trailer, title, mediaTypeId, contributorId));
                }
                return watchedMedia;
            }
            catch (Exception ex)
            {
                logger.LogError($"I return null because {ex.Message}");
                
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    } 
}
