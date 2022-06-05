using Domain.Developers.Entities;

namespace Services.Developers.Developers;

public interface IDeveloperService
{
    public Task<List<Developer>> GetAllDevelopers();
    
    public Task<List<Developer>> GetDevelopers(List<Guid> developerIds);

    public Task<Developer> GetDeveloper(Guid developerId);

    public Task<List<Project>> GetOwnedProjects(Guid developerId);

    public Task<List<Project>> GetDeveloperProjects(Guid developerId);
    
    public Task<List<Company>> GetOwnedCompanies(Guid developerId);
    
    public Task<List<Company>> GetDeveloperCompanies(Guid developerId);

    public Task<List<Tag>> GetDeveloperTags(Guid developerId);
 
    public Task<Guid> CreateDeveloper(string name);

    public Task UpdateName(Guid developerId, string name);

    public Task UpdateProjects(Guid developerId, List<Guid> projectIds);

    public Task UpdateCompanies(Guid developerId, List<Guid> companyIds);

    public Task UpdateTags(Guid developerId, List<int> tagIds);
}