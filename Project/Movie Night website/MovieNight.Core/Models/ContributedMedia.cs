

namespace Movie_Night_website.Models
{
    public class ContributedMedia 
    {
        private int _id;

        public int UserID;

        public int MediaID;

        public bool Votedin;

        public required MediaType MediaType;

        public ContributedMedia(int id, int userID, int mediaID, bool votedin, MediaType mediaType)
        {
            _id = id;
            UserID = userID;
            MediaID = mediaID;
            Votedin = votedin;
            MediaType = mediaType;
        }
    }
}




