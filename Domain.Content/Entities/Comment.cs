using Domain.Developers.Entities;
using Domain.Developers.Interfaces;

namespace Domain.Content.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public IDeveloper Developer { get; set; }
        public string Text { get; set; }
        public Post Post { get; set; }

        public Comment(string text, IDeveloper developer, Post post)
        {
            Developer = developer;
            Text = text;
            Post = post;
        }
        
        private Comment() {}
    }
}