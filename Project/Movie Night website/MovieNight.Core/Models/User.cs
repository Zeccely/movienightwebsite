namespace Movie_Night_website.Models
{
    public class User
    {
        private int UserID { get; set; }

        private string Username { get; set; }

        private string Password { get; set; }

        private Role Role { get; }

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
        public int GetUserID() {  return UserID; }
        public void SetUserID(int userId) {  UserID = userId; }
        public string GetUserName() { return Username; }
        public void SetUserName(string userName) { Username = userName; }
        public string GetPassword() { return Password; }
        public void SetPassword(string password) { Password = password; } // very suspicious method to be fair do I need this?
        public Role GetRole() { return Role; }
        
    }
}

public enum Role
{
    Regular,
    Organizer
}
