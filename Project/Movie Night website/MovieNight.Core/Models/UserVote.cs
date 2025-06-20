namespace Movie_Night_website.Models
{
    public class UserVote //hmm....
    {
        public int UserID { get; set; }

        public int MediaID { get; set; }

        public bool Liked { get; set; }

        public UserVote(int userID, int contenderMediaID, bool liked)
        {
            UserID = userID;
            MediaID = contenderMediaID;
            Liked = liked;
        }
    }

}


