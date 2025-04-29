namespace Movie_Night_website.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserPower PowerLevel { get; }

        public User(int userID, string username, string password, UserPower powerLevel)
        {
            UserID = userID;
            Username = username;
            Password = password;
            PowerLevel = powerLevel;
        }
    }
}

public enum UserPower
{
    Regular,
    Organizer
}
