namespace Movie_Night_website.Models
{
    public class MovieNight
    {
        public List<User> Atendees { get; set; } = new List<User>();

        public IMedia WatchedShow { get; set; }

        public DateTime WatchedDate { get; set; }

        public MovieNightStatus Status { get; set; }



    }
}

public enum MovieNightStatus
{
    PreEvent,
    Completed
}
