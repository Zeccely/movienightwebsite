using System.CodeDom;

namespace Movie_Night_website.Models
{
    public class Media
    {
        public int MediaID { get; set; }

        public string TrailerURL { get; set; }

        public string Title { get; set; }

        public MediaType MediaType { get; set; }
        public int UserID { get; set; }
        public User Contributor { get; set; }

        public Media (int mediaID, string trailerURL, string title, MediaType mediaType)
        {
            MediaID = mediaID;
            TrailerURL = trailerURL;
            Title = title;
            MediaType = mediaType;
        }

        public Media GetMedia() 
        {
            return null;
        }
    }
}
