using Domain.Developers.Interfaces;
using Services.Developers.DTOs;

namespace Services.Developers.Interfaces;

public interface IProjectService
{
    public Task<IProject?> GetProject(Guid id);

    public Task<IProject?> CreateProject(ProjectDto dto);

    public Task<IProject?> UpdateProject(ProjectDto dto);
}