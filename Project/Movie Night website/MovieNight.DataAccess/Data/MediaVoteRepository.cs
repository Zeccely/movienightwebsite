using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Movie_Night_website.Models;
using Movie_Night_Website.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Night_Website.DataAccess.Data
{
    public class MediaVoteRepository : IMediaVoteRepository
    {
        private string connectionString;

        public MediaVoteRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("HomeConnection");
        }

        public int GetPositiveVotes(int mediaId) //count the votes on this movie
        {
            int count = 0;
            string query = "Select Count(*) from UserVotes where Media_Id = @MediaId and Liked = 1";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@MediaId", mediaId);
                count = (int)sqlCommand.ExecuteScalar();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return 0;

        }

        public int GetNegativeVotes(int mediaId)
        {
            int count = 0;
            string query = "Select Count(*) from UserVotes where Media_Id = @MediaId and Liked = 0";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@MediaId", mediaId);
                count = (int)sqlCommand.ExecuteScalar();
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return 0;
        }

      

        public void CastVote(int userID, int mediaID, bool vote) //should I bool this
        {
            
            if (UserVoteCheck(userID, mediaID))
            {
                return;
            }

            string query = "Insert into UserVotes (User_Id, Media_Id, Liked) Values (@ContributorID, @MediaID, @Vote) ";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ContributorID", userID);
                sqlCommand.Parameters.AddWithValue("@MediaID", mediaID);
                sqlCommand.Parameters.AddWithValue("@Vote", vote);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void SetFinalVerdict(int mediaId, bool verdict)
        {
            string query = "Update Media Set FinalVerdict = @verdict where Id = @mediaId";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            
            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@verdict", verdict);
                sqlCommand.Parameters.AddWithValue("@mediaId", mediaId);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool UserVoteCheck(int userId, int mediaId)
        {
            string query = "Select * from UserVotes where User_Id = @userId and Media_Id = @mediaId";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@userId", userId);
                sqlCommand.Parameters.AddWithValue("@mediaId", mediaId);
                

                using SqlDataReader reader = sqlCommand.ExecuteReader();
                return reader.HasRows; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return false;
        }
    }
}
