using Domain.Developers.Interfaces;

namespace Domain.Payments.Entities;

public class Wallet
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public IUser User { get; set; }
    
    public Wallet(int id, int amount, IUser user)
    {
        Id = id;
        Amount = amount;
        User = user;
    }
}