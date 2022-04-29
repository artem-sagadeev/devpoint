using Microsoft.AspNetCore.Mvc;
using Services.Content.Comments;

namespace Web.API.Controllers.Content;

[ApiController]
[Route("comments")]
public class CommentController : Controller
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllComments()
    {
        var comments = await _commentService.GetAllComments();

        return Ok(comments);
    }

    [HttpGet]
    [Route("{commentIds}")]
    public async Task<IActionResult> GetComments(List<int> commentIds)
    {
        var comments = await _commentService.GetComments(commentIds);

        return Ok(comments);
    }

    [HttpGet]
    [Route("{commentId:int}")]
    public async Task<IActionResult> GetComment(int commentId)
    {
        var comment = await _commentService.GetComment(commentId);

        return Ok(comment);
    }

    [HttpGet]
    [Route("{commentId:int}/author")]
    public async Task<IActionResult> GetCommentAuthor(int commentId)
    {
        var author = await _commentService.GetCommentAuthor(commentId);

        return Ok(author);
    }

    [HttpGet]
    [Route("{commentId:int}/post")]
    public async Task<IActionResult> GetCommentPost(int commentId)
    {
        var post = await _commentService.GetCommentPost(commentId);

        return Ok(post);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateComment(string text, Guid authorId, int postId)
    {
        var commentId = await _commentService.CreateComment(text, authorId, postId);

        return Ok(commentId);
    }

    [HttpPut]
    [Route("{commentId:int}/update/text")]
    public async Task<IActionResult> UpdateText(int commentId, string text)
    {
        await _commentService.UpdateText(commentId, text);

        return Ok();
    }
}