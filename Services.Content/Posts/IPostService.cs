using Domain.Content.Entities;
using Domain.Developers.Entities;
using Domain.Subscriptions.Entities;

namespace Services.Content.Posts;

public interface IPostService
{
    public Task<List<Post>> GetAllPosts();

    public Task<List<Post>> GetPosts(List<int> postIds);

    public Task<Post> GetPost(int postId);

    public Task<SubscriptionLevel> GetRequiredSubscriptionLevel(int postId);

    public Task<Developer> GetPostAuthor(int postId);

    public Task<Project> GetPostProject(int postId);

    public Task<List<Comment>> GetPostComments(int postId);

    public Task<int> CreatePost(string text, int subscriptionLevelId, Guid developerId, Guid projectId);

    public Task UpdateText(int postId, string text);

    public Task UpdateRequiredSubscriptionLevel(int postId, int subscriptionLevelId);
}