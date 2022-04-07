using Domain.Developers.Interfaces;

namespace Domain.Developers.Entities
{
    public class Project : IProject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Tag> Tags { get; set; }

        public Project(string name, Developer owner, IEnumerable<Tag> tags)
        {
            Name = name;
            Developers = new List<Developer> {owner};
            Tags = new List<Tag>(tags);
        }

        public void AddUser(Developer developer)
        {
            Developers.Add(developer);
        }

        public void AddTags(IEnumerable<Tag> tags)
        {
            Tags.AddRange(tags);
        }
        
        private Project() {}
    }
}