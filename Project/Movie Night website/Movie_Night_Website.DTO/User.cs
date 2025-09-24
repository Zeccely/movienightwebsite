namespace Movie_Night_Website.DTO
{
    public class User
    {
        public int UserID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

    }

}

public enum Role
{
    Regular,
    Organizer
}
