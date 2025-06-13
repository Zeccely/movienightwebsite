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
            connectionString = configuration.GetConnectionString("LaptopConnection");
        }

        public int EvaluateVotes(int mediaId) //count the votes on this movie
        {
            string query = "Select Liked from UserVotes where Media_Id = @MediaId";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();

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

        public void CastVote(int userID, int mediaID, bool vote)
        {
            string query = "Insert into UserVote (User_Id, Media_Id, Liked) Values (@UserID, @MediaID, @Vote) ";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@UserID", userID);
                sqlCommand.Parameters.AddWithValue("@MediaID", mediaID);
                sqlCommand.Parameters.AddWithValue("@Liked", vote);
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

        public void UserVoteCheck(int userId, int mediaId)
        {
            //did user vote on media?
        }
    }
}
