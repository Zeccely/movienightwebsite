namespace Movie_Night_website.Models
{
    public class EpisodeHistory
    {
        public int UserID { get; set; }

        public int EpisodeID { get; set; }

        public DateTime DateWatched { get; set; }

        public EpisodeHistory(int userID, int episodeID, DateTime datewatched)
        {
            UserID = userID;
            EpisodeID = episodeID;
            DateWatched = datewatched;
        }
    }
}
