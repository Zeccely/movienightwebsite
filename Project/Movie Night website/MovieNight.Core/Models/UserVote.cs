namespace Movie_Night_website.Models
{
    public class UserVote //hmm....
    {
        public int UserID { get; set; }

        public int ContenderMediaID { get; set; }

        public bool Liked { get; set; }

        public UserVote(int userID, int contenderMediaID, bool liked)
        {
            UserID = userID;
            ContenderMediaID = contenderMediaID;
            Liked = liked;
        }
    }

}


