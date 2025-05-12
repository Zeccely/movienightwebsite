namespace Movie_Night_website.Models
{
    public class Episode
    {
        public int EpisodeID { get; set; }

        public int SeriesID { get; set; }

        public string EpisodeTitle { get; set; }

        public int EpisodeNumber { get; set; }

        public Episode(int episodeID, int seriesID, string episodeTitle, int episodeNumber)
        {
            EpisodeID = episodeID;
            SeriesID = seriesID;
            EpisodeTitle = episodeTitle;
            EpisodeNumber = episodeNumber;
        }
    }
}
