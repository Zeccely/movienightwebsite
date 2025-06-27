namespace Movie_Night_website.Models
{
    public class UserVote //hmm....
    {
        private int UserID { get; set; }

        private int MediaID { get; set; }

        private bool Liked { get; set; }

        public UserVote(int userID, int contenderMediaID, bool liked)
        {
            UserID = userID;
            MediaID = contenderMediaID;
            Liked = liked;
        }

        public int GetUserID() {  return UserID; }
        public void SetUserID(int userID) { UserID = userID; }
        public int GetMediaID() { return MediaID; }
        public void SetMediaID(int mediaID) { MediaID = mediaID; }
        public bool GetLiked() { return Liked; } //Do I need this?
        public void SetLiked(bool liked) { Liked = liked; }

    }

}


