using Domain.Developers.Interfaces;

namespace Domain.Developers.Entities
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
        public List<Company> Companies { get; set; }
        public List<Tag> Tags { get; set; }

        public User(string name, IEnumerable<Tag> tags)
        {
            Name = name;
            Tags = new List<Tag>(tags);
        }

        public void AddTags(IEnumerable<Tag> tags)
        {
            Tags.AddRange(tags);   
        }
    }
}