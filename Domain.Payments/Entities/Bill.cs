using Domain.Subscriptions.Entities.Subscriptions;

namespace Domain.Payments.Entities;

public class Bill
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public Wallet Wallet { get; set; }
    public Subscription Subscription { get; set; }
    
    public Bill(int id, int amount, Wallet wallet, Subscription subscription)
    {
        Id = id;
        Amount = amount;
        Wallet = wallet;
        Subscription = subscription;
    }
    
    private Bill() {}
}