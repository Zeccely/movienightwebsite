namespace Movie_Night_website.Models
{
    public class MovieNight
    {
        public List<Media> OrganizerList { get; private set; } = [];

        public List<User> Attendees { get; private set; } = new List<User>();

        public Media ChosenMedia { get; private set; }

        public DateTime ScheduledDate { get; private set; }


        public MovieNight(List<Media> movieNightOrganizerList, List<User> atendees, Media watchedMedia, DateTime scheduleddate)
        {
            OrganizerList = movieNightOrganizerList;
            Attendees = atendees;
            ChosenMedia = watchedMedia;
            ScheduledDate = scheduleddate;
           
        }


    }
}
