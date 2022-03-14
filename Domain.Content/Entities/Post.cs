﻿using Domain.Developers.Interfaces;
using Domain.Subscriptions.Interfaces;

namespace Domain.Content.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ISubscriptionLevel RequiredSubscriptionLevel { get; set; }
        public IUser User { get; set; }
        public IProject Project { get; set; }
        public List<Comment> Comments { get; set; }

        public Post(string text, ISubscriptionLevel requiredSubscriptionLevel, IUser user, IProject project)
        {
            Text = text;
            RequiredSubscriptionLevel = requiredSubscriptionLevel;
            User = user;
            Project = project;
        }
        
        private Post() {}
    }
}