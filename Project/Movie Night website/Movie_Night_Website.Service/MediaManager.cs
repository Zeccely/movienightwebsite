using Movie_Night_website.Models;

namespace Movie_Night_website.Services
{
    public class MediaManager
    {
        public List<Media> ContributedMedia { get; set; } = [];

        public List<Media> TheCurrentList { get; set; } = [];

        

        public List<Media> WatchedMedia { get; set; } = [];
    }


}
