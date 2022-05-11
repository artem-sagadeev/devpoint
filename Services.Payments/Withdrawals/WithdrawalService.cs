using Data.Core;
using Domain.Payments.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Payments.Wallets;

namespace Services.Payments.Withdrawals;

public class WithdrawalService : IWithdrawalService
{
    private readonly ApplicationContext _context;
    private readonly IWalletService _walletService;

    public WithdrawalService(ApplicationContext context, IWalletService walletService)
    {
        _context = context;
        _walletService = walletService;
    }

    public async Task<List<Withdrawal>> GetAllWithdrawals()
    {
        var withdrawals = await _context.Withdrawals.ToListAsync();

        return withdrawals;
    }

    public async Task<List<Withdrawal>> GetWithdrawals(List<int> withdrawalIds)
    {
        var withdrawals = await _context
            .Withdrawals
            .Where(withdrawal => withdrawalIds.Contains(withdrawal.Id))
            .ToListAsync();

        return withdrawals;
    }

    public async Task<Withdrawal> GetWithdrawal(int withdrawalId)
    {
        var withdrawal = await _context.Withdrawals.FindAsync(withdrawalId);

        return withdrawal;
    }

    public async Task<Wallet> GetWithdrawalWallet(int withdrawalId)
    {
        var withdrawal = await GetWithdrawal(withdrawalId);
        await _context.Entry(withdrawal).Reference(w => w.Wallet).LoadAsync();

        return withdrawal.Wallet;
    }

    public async Task<int> CreateWithdrawal(int amount, int walletId)
    {
        var wallet = await _walletService.GetWallet(walletId);
        var withdrawal = new Withdrawal(amount, wallet);
        _context.Withdrawals.Add(withdrawal);
        await _context.SaveChangesAsync();

        return withdrawal.Id;
    }
}