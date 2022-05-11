using Microsoft.AspNetCore.Mvc;
using Services.Payments.Replenishments;
using Web.API.Controllers.Payments.DTOs;

namespace Web.API.Controllers.Payments;

[ApiController]
[Route("replenishments")]
public class ReplenishmentController : Controller
{
    private readonly IReplenishmentService _replenishmentService;

    public ReplenishmentController(IReplenishmentService replenishmentService)
    {
        _replenishmentService = replenishmentService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllReplenishments()
    {
        var replenishments = await _replenishmentService.GetAllReplenishments();
        var result = replenishments.Select(replenishment => new ReplenishmentDto(replenishment));

        return Ok(result);
    }

    [HttpGet]
    [Route("{replenishmentIds}")]
    public async Task<IActionResult> GetReplenishments(List<int> replenishmentIds)
    {
        var replenishments = await _replenishmentService.GetReplenishments(replenishmentIds);
        var result = replenishments.Select(replenishment => new ReplenishmentDto(replenishment));

        return Ok(result);
    }

    [HttpGet]
    [Route("{replenishmentId:int}")]
    public async Task<IActionResult> GetReplenishment(int replenishmentId)
    {
        var replenishment = await _replenishmentService.GetReplenishment(replenishmentId);
        var result = new ReplenishmentDto(replenishment);

        return Ok(result);
    }

    [HttpGet]
    [Route("{replenishmentId}/wallet")]
    public async Task<IActionResult> GetReplenishmentWallet(int replenishmentId)
    {
        var wallet = await _replenishmentService.GetReplenishmentWallet(replenishmentId);
        var result = new WalletDto(wallet);

        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateReplenishment(int amount, int walletId)
    {
        var replenishmentId = await _replenishmentService.CreateReplenishment(amount, walletId);

        return Ok(replenishmentId);
    }
}