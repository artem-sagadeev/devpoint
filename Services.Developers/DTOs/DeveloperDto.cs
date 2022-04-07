namespace Services.Developers.DTOs;

public class DeveloperDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public List<int> TagIds { get; set; }
}