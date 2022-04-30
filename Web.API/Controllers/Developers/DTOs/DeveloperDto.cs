using Domain.Developers.Entities;

namespace Web.API.Controllers.Developers.DTOs;

public class DeveloperDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public DeveloperDto(Developer developer)
    {
        Id = developer.Id;
        Name = developer.Name;
    }
}