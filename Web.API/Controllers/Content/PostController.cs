using Microsoft.AspNetCore.Mvc;
using Services.Content.Posts;

namespace Web.API.Controllers.Content;

[ApiController]
[Route("posts")]
public class PostController : Controller
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await _postService.GetAllPosts();

        return Ok(posts);
    }

    [HttpGet]
    [Route("{postIds}")]
    public async Task<IActionResult> GetPosts(List<int> postIds)
    {
        var posts = await _postService.GetPosts(postIds);

        return Ok(posts);
    }

    [HttpGet]
    [Route("{postId:int}")]
    public async Task<IActionResult> GetPost(int postId)
    {
        var post = await _postService.GetPost(postId);

        return Ok(post);
    }

    [HttpGet]
    [Route("{postId:int}/subscription-level")]
    public async Task<IActionResult> GetRequiredSubscriptionLevel(int postId)
    {
        var subscriptionLevel = await _postService.GetRequiredSubscriptionLevel(postId);

        return Ok(subscriptionLevel);
    }

    [HttpGet]
    [Route("{postId:int}/author")]
    public async Task<IActionResult> GetPostAuthor(int postId)
    {
        var author = await _postService.GetPostAuthor(postId);

        return Ok(author);
    }
    
    [HttpGet]
    [Route("{postId:int}/project")]
    public async Task<IActionResult> GetPostProject(int postId)
    {
        var project = await _postService.GetPostProject(postId);

        return Ok(project);
    }
    
    [HttpGet]
    [Route("{postId:int}/comments")]
    public async Task<IActionResult> GetPostComments(int postId)
    {
        var comments = await _postService.GetPostComments(postId);

        return Ok(comments);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreatePost(string text, int subscriptionLevelId, Guid developerId, Guid projectId)
    {
        var postId = await _postService.CreatePost(text, subscriptionLevelId, developerId, projectId);

        return Ok(postId);
    }

    [HttpPut]
    [Route("{postId:int}/update/text")]
    public async Task<IActionResult> UpdateText(int postId, string text)
    {
        await _postService.UpdateText(postId, text);

        return Ok();
    }

    [HttpPut]
    [Route("{postId:int}/update/subscription-level")]
    public async Task<IActionResult> UpdateSubscriptionLevel(int postId, int subscriptionLevelId)
    {
        await _postService.UpdateRequiredSubscriptionLevel(postId, subscriptionLevelId);

        return Ok();
    }
}