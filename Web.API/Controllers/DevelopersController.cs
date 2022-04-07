using Domain.Developers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Developers.DTOs;
using Services.Developers.Interfaces;

namespace Web.API.Controllers;

[ApiController]
[Route("developers")]
public class DevelopersController : Controller
{
    private readonly IDeveloperService _developerService;

    public DevelopersController(IDeveloperService developerService)
    {
        _developerService = developerService;
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetDeveloper(Guid id)
    {
        var result = await _developerService.GetDeveloper(id);

        return Ok(result);
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateDeveloper(DeveloperDto dto)
    {
        var result = await _developerService.CreateDeveloper(dto);

        return Ok(result);
    }
    
    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateDeveloper(DeveloperDto dto)
    {
        var result = await _developerService.UpdateDeveloper(dto);

        return Ok(result);
    }
}