using Domain.Payments.Entities;

namespace Services.Payments.Replenishments;

public interface IReplenishmentService
{
    public Task<List<Replenishment>> GetAllReplenishments();

    public Task<List<Replenishment>> GetReplenishments(List<int> replenishmentIds);

    public Task<Replenishment> GetReplenishment(int replenishmentId);

    public Task<Wallet> GetReplenishmentWallet(int replenishmentId);

    public Task<int> CreateReplenishment(int amount, int walletId);
}