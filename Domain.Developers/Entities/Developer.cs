using Domain.Developers.Interfaces;

namespace Domain.Developers.Entities
{
    public class Developer : IDeveloper
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
        public List<Company> Companies { get; set; }
        public List<Tag> Tags { get; set; }
        
        public Developer(string name, List<Tag> tags)
        {
            Id = Guid.NewGuid();
            Name = name;
            Tags = tags;
        }

        public void Update(string name, List<Tag> tags)
        {
            Name = name;
            Tags = tags;
        }
        
        private Developer() {}
    }
}