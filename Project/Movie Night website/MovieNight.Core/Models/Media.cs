using System.CodeDom;

namespace Movie_Night_website.Models
{
    public class Media
    {
        public int MediaID { get; private set; }
        public string TrailerURL { get; private set; }
        public string Title { get; private set; }
        public MediaType MediaType { get; private set; }
        public int MediaTypeID { get; private set; }
        public int ContributorID { get; private set; }
        public User Contributor { get; private set; }

        public Media (int mediaID, string trailerURL, string title, MediaType mediaType)
        {
            MediaID = mediaID;
            TrailerURL = trailerURL;
            Title = title;
            MediaType = mediaType;
        }

        public Media(int mediaID, string trailerURL, string title, int mediaTypeId, int contributor)
        {
            MediaID = mediaID;
            TrailerURL = trailerURL;
            Title = title;
            MediaTypeID = mediaTypeId;
            ContributorID = contributor;
        }


    }
}
