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
    public class MovieNightRepository : IMovieNightRepository
    {
        private readonly string connectionString;
        public MovieNightRepository(ILogger<MovieNightRepository> logger, IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("Deployed");
        }

        public void AddUsersToMovieNight(List<int> userIds, int mediaId)
        {
            
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();
            string Nightquery = """
                Insert into MovieNight (Media_Id, DateOfEvent) Values (@Media_Id, @Datetime)
                Select Scope_Identity();
                """;
            string attendeeQuery = "Insert into MovieAttendees(User_Id, MovieNight_Id) Values(@UserId, @MovieNightId)";


            DateTime dateTime = GetNextFridayAt19();
            int movieNightId = 0;

            if(userIds == null || userIds.Count == 0 || mediaId == 0) 
            {
                return; 
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(Nightquery, sqlConnection))
                {   
                    cmd.Parameters.AddWithValue("@Media_Id", mediaId);
                    cmd.Parameters.AddWithValue("@Datetime", dateTime);
                    movieNightId = (int)(decimal)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            try
            {
                foreach (int userId in userIds)
                {
                    using SqlCommand sqlCommand = new SqlCommand(attendeeQuery, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@UserId", userId);
                    sqlCommand.Parameters.AddWithValue("@MovieNightId", movieNightId);
                    sqlCommand.ExecuteNonQuery();
                }
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

        public int GetMovieNightId(int mediaId)
        {
            string query = "Select Id From MovieNight Where Media_Id = @MediaId";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@MediaId", mediaId);
                int movieNightId = (int)sqlCommand.ExecuteScalar();

                return movieNightId;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void RemoveUserFromMovieNight(int userId, int movieNightId)
        {
            string query = "Delete From MovieAttendees Where User_Id = @UserId and MovieNight_Id = @MovieNightId";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                sqlCommand.Parameters.AddWithValue("@MovieNightId", movieNightId);

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

        public void CreateMovieNight(int mediaId) //Merged with add movies
        {
            string query = "Insert into MovieNight (Media_Id, DateOfEvent) Values (@Media_Id, @Datetime) ";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            DateTime dateTime = GetNextFridayAt19();
            try
            {
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Media_Id", mediaId);
                sqlCommand.Parameters.AddWithValue("@Datetime", dateTime);

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

        public DateTime GetNextFridayAt19()
        {
            DateTime now = DateTime.Now;
            int daysUntilFriday = ((int)DayOfWeek.Friday - (int)now.DayOfWeek + 7) % 7;

            if (daysUntilFriday == 0 && now.Hour >= 19)
                daysUntilFriday = 7;

            return now.Date.AddDays(daysUntilFriday).AddHours(19);
        }

    }
}
