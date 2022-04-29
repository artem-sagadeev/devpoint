using Microsoft.AspNetCore.Mvc;
using Services.Developers.Tags;

namespace Web.API.Controllers;

[ApiController]
[Route("tags")]
public class TagController : Controller
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllTags()
    {
        var tags = await _tagService.GetAllTags();

        return Ok(tags);
    }

    [HttpGet]
    [Route("{tagIds}")]
    public async Task<IActionResult> GetTags(List<int> tagIds)
    {
        var tags = await _tagService.GetTags(tagIds);

        return Ok(tags);
    }

    [HttpGet]
    [Route("{tagId:int}")]
    public async Task<IActionResult> GetTag(int tagId)
    {
        var tag = await _tagService.GetTag(tagId);

        return Ok(tag);
    }

    [HttpGet]
    [Route("{tagId:int}/developers")]
    public async Task<IActionResult> GetTagDevelopers(int tagId)
    {
        var developers = await _tagService.GetTagDevelopers(tagId);

        return Ok(developers);
    }

    [HttpGet]
    [Route("{tagId:int}/projects")]
    public async Task<IActionResult> GetTagProjects(int tagId)
    {
        var projects = await _tagService.GetTagProjects(tagId);

        return Ok(projects);
    }

    [HttpGet]
    [Route("{tagId:int}/companies")]
    public async Task<IActionResult> GetTagCompanies(int tagId)
    {
        var companies = await _tagService.GetTagCompanies(tagId);

        return Ok(companies);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateTag(string text)
    {
        var tagId = await _tagService.CreateTag(text);

        return Ok(tagId);
    }

    [HttpPut]
    [Route("{tagId:int}/update/text")]
    public async Task<IActionResult> UpdateText(int tagId, string text)
    {
        await _tagService.UpdateText(tagId, text);

        return Ok();
    }
}