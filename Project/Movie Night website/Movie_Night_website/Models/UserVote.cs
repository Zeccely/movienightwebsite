namespace Movie_Night_website.Models
{
    public class UserVote
    {
        public int UserID;

        public int ContenderMediaID;


        public VoteStatus Status;
    }
}

public enum VoteStatus
{
    Pending,
    Approved,
    Denied
}
