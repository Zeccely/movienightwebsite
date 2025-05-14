namespace Movie_Night_website.Models
{
    public class MediaType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public MediaType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
