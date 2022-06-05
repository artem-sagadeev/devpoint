namespace Domain.Developers.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Developer Owner { get; set; }
        public Company? Company { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Tag> Tags { get; set; }

        public Project(string name, Developer owner, Company? company)
        {
            Name = name;
            Owner = owner;
            Company = company;
            Developers = new List<Developer> {owner};
        }
        
        private Project() {}
    }
}