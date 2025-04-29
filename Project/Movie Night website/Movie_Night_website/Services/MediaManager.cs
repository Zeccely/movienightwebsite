using Movie_Night_website.Models;

namespace Movie_Night_website.Services
{
    public class MediaManager
    {
        public List<IMedia> ContributedMedia { get; set; } = [];

        public List<IMedia> TheCurrentList { get; set; } = [];

        

        public List<IMedia> WatchedMedia { get; set; } = [];
    }


}
