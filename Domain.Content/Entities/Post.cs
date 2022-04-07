using Domain.Developers.Interfaces;
using Domain.Subscriptions.Interfaces;

namespace Domain.Content.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ISubscriptionLevel RequiredSubscriptionLevel { get; set; }
        public IDeveloper Developer { get; set; }
        public IProject Project { get; set; }
        public List<Comment> Comments { get; set; }

        public Post(string text, ISubscriptionLevel requiredSubscriptionLevel, IDeveloper developer, IProject project)
        {
            Text = text;
            RequiredSubscriptionLevel = requiredSubscriptionLevel;
            Developer = developer;
            Project = project;
        }
        
        private Post() {}
    }
}