using Domain.Developers.Entities;

namespace Domain.Payments.Entities;

public class Wallet
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public Developer Developer { get; set; }
    
    public Wallet(int id, int amount, Developer developer)
    {
        Id = id;
        Amount = amount;
        Developer = developer;
    }
    
    private Wallet() {}
}