using Data.Core;
using Domain.Developers.Entities;
using Domain.Developers.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Developers.DTOs;
using Services.Developers.Interfaces;

namespace Services.Developers;

public class ProjectService : IProjectService
{
    private readonly ApplicationContext _context;

    public ProjectService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IProject?> GetProject(Guid id)
    {
        var project = await _context.Projects.FindAsync(id);

        return project;
    }

    public async Task<IProject?> CreateProject(ProjectDto dto)
    {
        var tags = await _context.Tags.Where(tag => dto.TagIds.Contains(tag.Id)).ToListAsync();
        var owner = await _context.Developers.FindAsync(dto.OwnerId);
        if (owner is null) 
            return null;
        var project = new Project(dto.Name, owner, tags);
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        
        return project;
    }

    public async Task<IProject?> UpdateProject(ProjectDto dto)
    {
        var tags = await _context.Tags.Where(tag => dto.TagIds.Contains(tag.Id)).ToListAsync();
        var project = await _context.Projects.FindAsync(dto.Id);
        if (project is null)
            return null;
        project.Update(dto.Name, tags);
        await _context.SaveChangesAsync();

        return project;
    }
}