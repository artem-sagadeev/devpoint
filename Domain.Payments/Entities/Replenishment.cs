namespace Domain.Payments.Entities;

public class Replenishment
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public Wallet Wallet { get; set; }
    
    public Replenishment(int id, int amount, Wallet wallet)
    {
        Id = id;
        Amount = amount;
        Wallet = wallet;
    }
    
    private Replenishment() {}
}