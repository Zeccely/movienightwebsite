namespace Movie_Night_Website.DTO
{
    public class MovieNight
    {
        public List<Media> OrganizerList { get;  set; } = [];

        public List<User> Attendees { get; set; } = new List<User>();

        public Media ChosenMedia { get; set; }

        public DateTime ScheduledDate { get; set; }


    }
}
