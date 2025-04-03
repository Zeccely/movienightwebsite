using System.ComponentModel.DataAnnotations;

namespace Movie_Night_website.Models
{
    public class Movie 
    {
        [Key]
        public int MovieID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string TrailerURL { get; set; } = string.Empty;

    }
}
