using Domain.Content.Entities;

namespace Web.API.Controllers.Content.DTOs;

public class PostDto
{
    public int Id { get; set; }
    public string Text { get; set; }

    public PostDto(Post post)
    {
        Id = post.Id;
        Text = post.Text;
    }
}