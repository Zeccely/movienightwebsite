using Movie_Night_website.Models;

namespace Movie_Night_website.Services
{
    public class MovieNight : IMedia
    {
        public List<User> Atendees { get; set; } = new List<User>();

        public IMedia? WatchedShow {  get; set; }

        public DateTime WatchedDate { get; set; }



    }
}
