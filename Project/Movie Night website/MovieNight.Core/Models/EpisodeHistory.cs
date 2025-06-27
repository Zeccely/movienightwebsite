namespace Movie_Night_website.Models
{
    public class EpisodeHistory
    {
        private int UserID { get; set; }

        private int EpisodeID { get; set; }

        private DateTime DateWatched { get; set; }

        public EpisodeHistory(int userID, int episodeID, DateTime datewatched)
        {
            UserID = userID;
            EpisodeID = episodeID;
            DateWatched = datewatched;
        }
    }
}
