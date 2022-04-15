using Domain.Developers.Interfaces;

namespace Domain.Developers.Entities
{
    public class Project : IProject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Company? Company { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Tag> Tags { get; set; }

        public Project(string name, Developer owner, List<Tag> tags)
        {
            Name = name;
            Developers = new List<Developer> {owner};
            Tags = tags;
        }
        
        public void Update(string name, List<Tag> tags)
        {
            Name = name;
            Tags = tags;
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