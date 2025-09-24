namespace Movie_Night_website.Models
{
    public class UserVote //hmm....
    {
        public int UserID { get; private set; }

        public int MediaID { get; private set; }

        public bool Liked { get; private set; }

        public UserVote(int userID, int contenderMediaID, bool liked)
        {
            UserID = userID;
            MediaID = contenderMediaID;
            Liked = liked;
        }
    }

}


