namespace Domain.Developers.Entities
{
    public class Developer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Project> OwnedProjects { get; set; }
        public List<Project> Projects { get; set; }
        public List<Company> OwnedCompanies { get; set; }
        public List<Company> Companies { get; set; }
        public List<Tag> Tags { get; set; }
        
        public Developer(string name)
        {
            Name = name;
        }
        
        private Developer() {}
    }
}