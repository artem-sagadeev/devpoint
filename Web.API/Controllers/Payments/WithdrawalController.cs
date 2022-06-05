using Microsoft.AspNetCore.Mvc;
using Services.Payments.Withdrawals;
using Web.API.Controllers.Payments.DTOs;

namespace Web.API.Controllers.Payments;

[ApiController]
[Route("withdrawals")]
public class WithdrawalController : Controller
{
    private readonly IWithdrawalService _withdrawalService;

    public WithdrawalController(IWithdrawalService withdrawalService)
    {
        _withdrawalService = withdrawalService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllWithdrawals()
    {
        var withdrawals = await _withdrawalService.GetAllWithdrawals();
        var result = withdrawals.Select(withdrawal => new WithdrawalDto(withdrawal));

        return Ok(result);
    }

    [HttpGet]
    [Route("withdrawalIds")]
    public async Task<IActionResult> GetWithdrawals(List<int> withdrawalIds)
    {
        var withdrawals = await _withdrawalService.GetWithdrawals(withdrawalIds);
        var result = withdrawals.Select(withdrawal => new WithdrawalDto(withdrawal));

        return Ok(result);
    }

    [HttpGet]
    [Route("{withdrawalId:int}")]
    public async Task<IActionResult> GetWithdrawal(int withdrawalId)
    {
        var withdrawal = await _withdrawalService.GetWithdrawal(withdrawalId);
        var result = new WithdrawalDto(withdrawal);

        return Ok(result);
    }

    [HttpGet]
    [Route("{withdrawalId:int}/wallet")]
    public async Task<IActionResult> GetWithdrawalWallet(int withdrawalId)
    {
        var wallet = await _withdrawalService.GetWithdrawalWallet(withdrawalId);
        var result = new WalletDto(wallet);

        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateWithdrawal(int amount, int walletId)
    {
        var withdrawalId = await _withdrawalService.CreateWithdrawal(amount, walletId);

        return Ok(withdrawalId);
    }
}