
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
    }
}
