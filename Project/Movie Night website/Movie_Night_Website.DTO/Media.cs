

namespace Movie_Night_Website.DTO
{
    public class Media
    {
        public int MediaID { get; set; }
        public string TrailerURL { get; set; }
        public string Title { get; set; }
        public MediaType MediaType { get; set; }
        public int MediaTypeID { get; set; }
        public int ContributorID { get; set; }
        public User Contributor { get; set; }


    }
}
