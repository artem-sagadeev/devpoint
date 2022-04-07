using Domain.Developers.Interfaces;
using Services.Developers.DTOs;

namespace Services.Developers.Interfaces;

public interface IProjectService
{
    public IProject GetProject(Guid id);

    public IProject CreateProject(ProjectDto dto);

    public IProject UpdateProject(ProjectDto dto);
}