using Data.Core;
using Domain.Payments.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Payments.Wallets;

namespace Services.Payments.Replenishments;

public class ReplenishmentService : IReplenishmentService
{
    private readonly ApplicationContext _context;
    private readonly IWalletService _walletService;

    public ReplenishmentService(ApplicationContext context, IWalletService walletService)
    {
        _context = context;
        _walletService = walletService;
    }

    public async Task<List<Replenishment>> GetAllReplenishments()
    {
        var replenishments = await _context.Replenishments.ToListAsync();

        return replenishments;
    }

    public async Task<List<Replenishment>> GetReplenishments(List<int> replenishmentIds)
    {
        var replenishments = await _context.Replenishments
            .Where(replenishment => replenishmentIds.Contains(replenishment.Id))
            .ToListAsync();

        return replenishments;
    }

    public async Task<Replenishment> GetReplenishment(int replenishmentId)
    {
        var replenishment = await _context.Replenishments.FindAsync(replenishmentId);

        return replenishment;
    }

    public async Task<Wallet> GetReplenishmentWallet(int replenishmentId)
    {
        var replenishment = await GetReplenishment(replenishmentId);
        await _context.Entry(replenishment).Reference(r => r.Wallet).LoadAsync();

        return replenishment.Wallet;
    }

    public async Task<int> CreateReplenishment(int amount, int walletId)
    {
        var wallet = await _walletService.GetWallet(walletId);
        var replenishment = new Replenishment(amount, wallet);
        _context.Replenishments.Add(replenishment);
        await _context.SaveChangesAsync();

        return replenishment.Id;
    }
}