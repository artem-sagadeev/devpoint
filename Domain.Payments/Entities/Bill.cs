using Domain.Subscriptions.Interfaces;

namespace Domain.Payments.Entities;

public class Bill
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public Wallet Wallet { get; set; }
    public ISubscription Subscription { get; set; }
    
    public Bill(int id, int amount, Wallet wallet, ISubscription subscription)
    {
        Id = id;
        Amount = amount;
        Wallet = wallet;
        Subscription = subscription;
    }
}