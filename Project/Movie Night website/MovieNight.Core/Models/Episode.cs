namespace Movie_Night_website.Models
{
    public class Episode
    {
        public int EpisodeID { get; private set; }

        public int SeriesID { get; private set; }

        public string EpisodeTitle { get; private set; }

        public int EpisodeNumber { get; private set; }

        public Episode(int episodeID, int seriesID, string episodeTitle, int episodeNumber)
        {
            EpisodeID = episodeID;
            SeriesID = seriesID;
            EpisodeTitle = episodeTitle;
            EpisodeNumber = episodeNumber;
        }
    }
}
