using Microsoft.Data.SqlClient;
using Movie_Night_website.Models;
using Movie_Night_Website.DataAccess.Data;

namespace Movie_Night_website.Services
{
    public class MediaManager
    {
        private readonly MovieNightDatabase _database;

        private MediaManager (MovieNightDatabase database)
        {
            _database = database;
        }

        public List<Media> ContributedMedia { get; set; } = [];

        public List<Media> TheCurrentList { get; set; } = [];

        public List<Media> WatchedMedia { get; set; } = [];

        public void AddMedia (string title, string trailerURL, int mediaTypeID, int userID)
        {
            _database.AddMediaToDB(title, trailerURL, mediaTypeID, userID);
        }
    }


}
