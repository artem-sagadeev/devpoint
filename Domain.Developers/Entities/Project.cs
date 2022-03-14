using Domain.Developers.Interfaces;

namespace Domain.Developers.Entities
{
    public class Project : IProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public List<User> Users { get; set; }
        public List<Tag> Tags { get; set; }

        public Project(string name, User owner, IEnumerable<Tag> tags)
        {
            Name = name;
            Users = new List<User> {owner};
            Tags = new List<Tag>(tags);
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void AddTags(IEnumerable<Tag> tags)
        {
            Tags.AddRange(tags);
        }
        
        private Project() {}
    }
}