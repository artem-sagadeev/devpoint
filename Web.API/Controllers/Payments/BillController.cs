using Microsoft.AspNetCore.Mvc;
using Services.Payments.Bills;
using Web.API.Controllers.Payments.DTOs;
using Web.API.Controllers.Subscriptions.DTOs;

namespace Web.API.Controllers.Payments;

[ApiController]
[Route("bills")]
public class BillController : Controller
{
    private readonly IBillService _billService;

    public BillController(IBillService billService)
    {
        _billService = billService;
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetAllBills()
    {
        var bills = await _billService.GetAllBills();
        var result = bills.Select(bill => new BillDto(bill));

        return Ok(result);
    }

    [HttpGet]
    [Route("{billIds}")]
    public async Task<IActionResult> GetBills(List<int> billIds)
    {
        var bills = await _billService.GetBills(billIds);
        var result = bills.Select(bill => new BillDto(bill));

        return Ok(result);
    }

    [HttpGet]
    [Route("{billId:int}")]
    public async Task<IActionResult> GetBill(int billId)
    {
        var bill = await _billService.GetBill(billId);
        var result = new BillDto(bill);

        return Ok(result);
    }

    [HttpGet]
    [Route("{billId:int}/wallet")]
    public async Task<IActionResult> GetBillWallet(int billId)
    {
        var wallet = await _billService.GetBillWallet(billId);
        var result = new WalletDto(wallet);

        return Ok(result);
    }

    [HttpGet]
    [Route("{billId:int}/subscription")]
    public async Task<IActionResult> GetBillSubscription(int billId)
    {
        var subscription = await _billService.GetBillSubscription(billId);
        var result = new SubscriptionDto(subscription);

        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateBill(int amount, int walletId, int subscriptionId)
    {
        var billId = await _billService.CreateBill(amount, walletId, subscriptionId);

        return Ok(billId);
    }
}