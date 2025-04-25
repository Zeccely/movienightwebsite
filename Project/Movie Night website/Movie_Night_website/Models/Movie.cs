using System.ComponentModel.DataAnnotations;

namespace Movie_Night_website.Models
{
    public class Movie : IMedia
    {
        [Key]
        public int MediaID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string TrailerURL { get; set; } = string.Empty;

        public Movie(int mediaID, string title, string trailerURL)
        {
            this.MediaID = mediaID;
            this.Title = title;
            this.TrailerURL = trailerURL;
        }
    }
}
