using Domain.Developers.Entities;
using Domain.Developers.Interfaces;

namespace Domain.Content.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public IUser User { get; set; }
        public string Text { get; set; }
        public Post Post { get; set; }

        public Comment(string text, IUser user, Post post)
        {
            User = user;
            Text = text;
            Post = post;
        }
        
        private Comment() {}
    }
}