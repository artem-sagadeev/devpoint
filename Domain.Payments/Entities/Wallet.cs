using Domain.Developers.Interfaces;

namespace Domain.Payments.Entities;

public class Wallet
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public IDeveloper Developer { get; set; }
    
    public Wallet(int id, int amount, IDeveloper developer)
    {
        Id = id;
        Amount = amount;
        Developer = developer;
    }
    
    private Wallet() {}
}