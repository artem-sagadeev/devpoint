using Data.Core;
using Domain.Developers.Entities;
using Domain.Developers.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Developers.DTOs;
using Services.Developers.Interfaces;

namespace Services.Developers;

public class DeveloperService : IDeveloperService
{
    private readonly ApplicationContext _context;

    public DeveloperService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IDeveloper?> GetDeveloper(Guid id)
    {
        var developer = await _context.Developers.FindAsync(id);

        return developer;
    }

    public async Task<IDeveloper> CreateDeveloper(DeveloperDto dto)
    {
        var tags = await _context.Tags.Where(tag => dto.TagIds.Contains(tag.Id)).ToListAsync();
        var developer = new Developer(dto.Name, tags);
        _context.Developers.Add(developer);
        await _context.SaveChangesAsync();

        return developer;
    }

    public async Task<IDeveloper?> UpdateDeveloper(DeveloperDto dto)
    {
        var developer = await _context.Developers.FindAsync(dto.Id);
        var tags = await _context.Tags.Where(tag => dto.TagIds.Contains(tag.Id)).ToListAsync();
        developer?.Update(dto.Name, tags);
        await _context.SaveChangesAsync();

        return developer;
    }
}