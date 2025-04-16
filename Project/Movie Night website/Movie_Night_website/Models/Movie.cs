using System.ComponentModel.DataAnnotations;

namespace Movie_Night_website.Models
{
    public class Movie : IMedia
    {
        [Key]
        public int MediaID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string TrailerURL { get; set; } = string.Empty;

        public Movie(int movieID, string title, string trailerURL)
        {
            this.MediaID = movieID;
            this.Title = title;
            this.TrailerURL = trailerURL;
        }
    }
}
