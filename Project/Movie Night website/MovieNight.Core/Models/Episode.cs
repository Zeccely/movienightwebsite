namespace Movie_Night_website.Models
{
    public class Episode
    {
        private int EpisodeID { get; set; }

        private int SeriesID { get; set; }

        private string EpisodeTitle { get; set; }

        private int EpisodeNumber { get; set; }

        public Episode(int episodeID, int seriesID, string episodeTitle, int episodeNumber)
        {
            EpisodeID = episodeID;
            SeriesID = seriesID;
            EpisodeTitle = episodeTitle;
            EpisodeNumber = episodeNumber;
        }
    }
}
