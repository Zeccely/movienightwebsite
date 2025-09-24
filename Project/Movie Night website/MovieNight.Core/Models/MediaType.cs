namespace Movie_Night_website.Models
{
    public class MediaType
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public MediaType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
