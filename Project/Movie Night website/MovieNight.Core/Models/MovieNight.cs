namespace Movie_Night_website.Models
{
    public class MovieNight
    {
        public List<Media> OrganizerList { get; set; } = [];

        public List<User> Attendees { get; set; } = new List<User>();

        public Media ChosenMedia { get; set; }

        public DateTime ScheduledDate { get; set; }


        public MovieNight(List<Media> movieNightOrganizerList, List<User> atendees, Media watchedMedia, DateTime scheduleddate)
        {
            OrganizerList = movieNightOrganizerList;
            Attendees = atendees;
            ChosenMedia = watchedMedia;
            ScheduledDate = scheduleddate;
           
        }


    }
}
