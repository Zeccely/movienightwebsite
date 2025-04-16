namespace Movie_Night_website.Models
{
    public class Series : IMedia
    {
        public int MediaID { get; set; }

        public string Title { get; set; }

        public string TrailerURL { get; set; }

        public string EpisodeTrack {  get; set; }
        
        public Series( int seriesID, string title, string trailerURL, string episodetrack )
        {
            this.MediaID = seriesID;
            this.Title = title;
            this.TrailerURL = trailerURL;
            this.EpisodeTrack = episodetrack;
        }


    }
}
