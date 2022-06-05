using Domain.Developers.Entities;
using Domain.Subscriptions.Entities;

namespace Domain.Content.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public SubscriptionLevel RequiredSubscriptionLevel { get; set; }
        public Developer Developer { get; set; }
        public Project Project { get; set; }
        public List<Comment> Comments { get; set; }

        public Post(string text, SubscriptionLevel requiredSubscriptionLevel, Developer developer, Project project)
        {
            Text = text;
            RequiredSubscriptionLevel = requiredSubscriptionLevel;
            Developer = developer;
            Project = project;
        }
        
        private Post() {}
    }
}