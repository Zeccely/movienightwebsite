namespace Movie_Night_website.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Role Role { get; }

        public User(int userID, string username, string password, Role role)
        {
            UserID = userID;
            Username = username;
            Password = password;
            Role = role;
        }

        public User(int userID, string username, Role role)
        {
            UserID=userID;
            Username = username;
            Role = role;
        }
    }
}

public enum Role
{
    Regular,
    Organizer
}
