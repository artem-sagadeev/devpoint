using Domain.Payments.Entities;

namespace Services.Payments.Withdrawals;

public interface IWithdrawalService
{
    public Task<List<Withdrawal>> GetAllWithdrawals();

    public Task<List<Withdrawal>> GetWithdrawals(List<int> withdrawalIds);

    public Task<Withdrawal> GetWithdrawal(int withdrawalId);

    public Task<Wallet> GetWithdrawalWallet(int withdrawalId);

    public Task<int> CreateWithdrawal(int amount, int walletId);
}