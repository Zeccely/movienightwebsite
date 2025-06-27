namespace Movie_Night_website.Models
{
    public class MediaType
    {
        private int Id { get; set; }
        private string Name { get; set; }

        public MediaType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int GetId() {  return Id; }
        public void SetId(int id) { Id = id; }
        public string GetName() { return Name; }
        public void SetName(string name) { Name = name; }
    }
}
