using Domain.Payments.Entities;
using Domain.Subscriptions.Entities.Subscriptions;

namespace Services.Payments.Bills;

public interface IBillService
{
    public Task<List<Bill>> GetAllBills();

    public Task<List<Bill>> GetBills(List<int> billIds);

    public Task<Bill> GetBill(int billId);

    public Task<Wallet> GetBillWallet(int billId);

    public Task<Subscription> GetBillSubscription(int billId);

    public Task<int> CreateBill(int amount, int walletId, int subscriptionId);
}