namespace Movie_Night_website.Models
{
    public class MovieNight
    {
        public List<Media> MovieNightOrganizerList { get; set; } = [];

        public List<User> Atendees { get; set; } = new List<User>();

        public Media ChosenMedia { get; set; }

        public DateTime ScheduledDate { get; set; }

        public MovieNightStatus Status { get; set; } //might not use this now but will implement later!

        public MovieNight(List<Media> movieNightOrganizerList, List<User> atendees, Media watchedMedia, DateTime scheduleddate, MovieNightStatus status)
        {
            MovieNightOrganizerList = movieNightOrganizerList;
            Atendees = atendees;
            ChosenMedia = watchedMedia;
            ScheduledDate = scheduleddate;
            Status = MovieNightStatus.PreEvent;
        }

        public void UpdateStatus(MovieNightStatus status)
        {
            Status = status;
        }


    }
}

public enum MovieNightStatus
{
    PreEvent,
    Confirmed,
    Completed
}
