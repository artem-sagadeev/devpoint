using Domain.Developers.Entities;

namespace Web.API.Controllers.Developers.DTOs;

public class ProjectDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ProjectDto(Project project)
    {
        Id = project.Id;
        Name = project.Name;
    }
}