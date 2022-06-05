using Data.Core;
using Domain.Payments.Entities;
using Domain.Subscriptions.Entities.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Services.Payments.Wallets;
using Services.Subscriptions.Subscriptions;

namespace Services.Payments.Bills;

public class BillService : IBillService
{
    private readonly ApplicationContext _context;
    private readonly IWalletService _walletService;
    private readonly ISubscriptionService _subscriptionService;

    public BillService(ApplicationContext context, IWalletService walletService, ISubscriptionService subscriptionService)
    {
        _context = context;
        _walletService = walletService;
        _subscriptionService = subscriptionService;
    }

    public async Task<List<Bill>> GetAllBills()
    {
        var bills = await _context.Bills.ToListAsync();

        return bills;
    }

    public async Task<List<Bill>> GetBills(List<int> billIds)
    {
        var bills = await _context.Bills.Where(bill => billIds.Contains(bill.Id)).ToListAsync();

        return bills;
    }

    public async Task<Bill> GetBill(int billId)
    {
        var bill = await _context.Bills.FindAsync(billId);

        return bill;
    }

    public async Task<Wallet> GetBillWallet(int billId)
    {
        var bill = await GetBill(billId);
        await _context.Entry(bill).Reference(b => b.Wallet).LoadAsync();

        return bill.Wallet;
    }

    public async Task<Subscription> GetBillSubscription(int billId)
    {
        var bill = await GetBill(billId);
        await _context.Entry(bill).Reference(b => b.Subscription).LoadAsync();

        return bill.Subscription;
    }

    public async Task<int> CreateBill(int amount, int walletId, int subscriptionId)
    {
        var wallet = await _walletService.GetWallet(walletId);
        var subscription = await _subscriptionService.GetSubscription(subscriptionId);
        var bill = new Bill(amount, wallet, subscription);
        _context.Bills.Add(bill);
        await _context.SaveChangesAsync();

        return bill.Id;
    }
}