namespace Movie_Night_website.Models
{
    public class EpisodeHistory
    {
        public int UserID { get; private set; }

        public int EpisodeID { get; private set; }

        public DateTime DateWatched { get; private set; }

        public EpisodeHistory(int userID, int episodeID, DateTime datewatched)
        {
            UserID = userID;
            EpisodeID = episodeID;
            DateWatched = datewatched;
        }
    }
}
