using Domain.Developers.Interfaces;
using Services.Developers.DTOs;

namespace Services.Developers.Interfaces;

public interface IDeveloperService
{
    public Task<IDeveloper?> GetDeveloper(Guid id);

    public Task<IDeveloper> CreateDeveloper(DeveloperDto dto);

    public Task<IDeveloper?> UpdateDeveloper(DeveloperDto dto);
}