using Data.Core;
using Domain.Content.Entities;
using Domain.Developers.Entities;
using Domain.Subscriptions.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Developers.Developers;
using Services.Developers.Projects;
using Services.Subscriptions.SubscriptionLevels;

namespace Services.Content.Posts;

public class PostService : IPostService
{
    private readonly ApplicationContext _context;
    private readonly IDeveloperService _developerService;
    private readonly ISubscriptionLevelService _subscriptionLevelService;
    private readonly IProjectService _projectService;

    public PostService(ApplicationContext context, IDeveloperService developerService, ISubscriptionLevelService subscriptionLevelService, IProjectService projectService)
    {
        _context = context;
        _developerService = developerService;
        _subscriptionLevelService = subscriptionLevelService;
        _projectService = projectService;
    }

    public async Task<List<Post>> GetAllPosts()
    {
        var posts = await _context.Posts.ToListAsync();

        return posts;
    }

    public async Task<List<Post>> GetPosts(List<int> postIds)
    {
        var posts = await _context.Posts.Where(post => postIds.Contains(post.Id)).ToListAsync();

        return posts;
    }

    public async Task<Post> GetPost(int postId)
    {
        var post = await _context.Posts.FindAsync(postId);

        return post;
    }

    public async Task<SubscriptionLevel> GetRequiredSubscriptionLevel(int postId)
    {
        var post = await GetPost(postId);
        await _context.Entry(post).Reference(p => p.RequiredSubscriptionLevel).LoadAsync();

        return post.RequiredSubscriptionLevel;
    }

    public async Task<Developer> GetPostAuthor(int postId)
    {
        var post = await GetPost(postId);
        await _context.Entry(post).Reference(p => p.Developer).LoadAsync();

        return post.Developer;
    }

    public async Task<Project> GetPostProject(int postId)
    {
        var post = await GetPost(postId);
        await _context.Entry(post).Reference(p => p.Project).LoadAsync();

        return post.Project;
    }

    public async Task<List<Comment>> GetPostComments(int postId)
    {
        var post = await GetPost(postId);
        await _context.Entry(post).Collection(p => p.Comments).LoadAsync();

        return post.Comments;
    }

    public async Task<int> CreatePost(string text, int subscriptionLevelId, Guid developerId, Guid projectId)
    {
        var subscriptionLevel = await _subscriptionLevelService.GetSubscriptionLevel(subscriptionLevelId);
        var developer = await _developerService.GetDeveloper(developerId);
        var project = await _projectService.GetProject(projectId);
        var post = new Post(text, subscriptionLevel, developer, project);
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        return post.Id;
    }

    public async Task UpdateText(int postId, string text)
    {
        var post = await GetPost(postId);
        post.Text = text;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRequiredSubscriptionLevel(int postId, int subscriptionLevelId)
    {
        var post = await GetPost(postId);
        var subscriptionLevel = await _subscriptionLevelService.GetSubscriptionLevel(subscriptionLevelId);
        post.RequiredSubscriptionLevel = subscriptionLevel;
        await _context.SaveChangesAsync();
    }
}