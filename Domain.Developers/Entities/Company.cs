using Domain.Developers.Interfaces;

namespace Domain.Developers.Entities
{
    public class Company : ICompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public List<User> Users { get; set; }
        public List<Project> Projects { get; set; }
        public List<Tag> Tags { get; set; }

        public Company(string name, User owner, IEnumerable<Tag> tags)
        {
            Name = name;
            Users = new List<User> {owner};
            Tags = new List<Tag>(tags);
        }

        public void AddCoordinates(decimal latitude, decimal longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        
        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void AddProject(Project project)
        {
            Projects.Add(project);
        }

        public void AddTags(IEnumerable<Tag> tags)
        {
            Tags.AddRange(tags);
        }
    }
}