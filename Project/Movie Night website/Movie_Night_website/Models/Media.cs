namespace Movie_Night_website.Models
{
    public class Media
    {
        public int MediaID { get; set; }

        public string TrailerURL { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public MediaType MediaType { get; set; }

        public Media (int mediaID, string trailerURL, string title, string genre, MediaType mediaType)
        {
            MediaID = mediaID;
            TrailerURL = trailerURL;
            Title = title;
            Genre = genre;
            MediaType = mediaType;
        }
    }
}
