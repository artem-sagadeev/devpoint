namespace Services.Developers.DTOs;

public class ProjectDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public Guid OwnerId { get; set; }
    public List<int> TagIds { get; set; }
}