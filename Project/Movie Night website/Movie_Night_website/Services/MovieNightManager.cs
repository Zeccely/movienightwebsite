using Movie_Night_website.Models;

namespace Movie_Night_website.Services
{
    public class MovieNightManager
    {
        public List<IMedia> ContenderMedia { get; set; } = [];

        public List<IMedia> TheCurrentList { get; set; } = [];

        public List<IMedia> MovieNightOrganizerList { get; set; } = [];

        public List<IMedia> WatchedMedia { get; set; } = [];
    }
}
