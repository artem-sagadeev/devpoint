using Domain.Developers.Interfaces;

namespace Domain.Developers.Entities
{
    public class Company : ICompany
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Project> Projects { get; set; }
        public List<Tag> Tags { get; set; }

        public Company(string name, Developer owner, IEnumerable<Tag> tags)
        {
            Name = name;
            Developers = new List<Developer> {owner};
            Tags = new List<Tag>(tags);
        }

        public void AddCoordinates(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        
        public void AddUser(Developer developer)
        {
            Developers.Add(developer);
        }

        public void AddProject(Project project)
        {
            Projects.Add(project);
        }

        public void AddTags(IEnumerable<Tag> tags)
        {
            Tags.AddRange(tags);
        }
        
        private Company() {}
    }
}