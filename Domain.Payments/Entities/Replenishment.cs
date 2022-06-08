namespace Domain.Payments.Entities;

public class Replenishment
{
    public int Id { get; set; }
    public int Amount { get; set; }
    
    public DateTime DateTime { get; set; }
    public Wallet Wallet { get; set; }
    
    public Replenishment(int amount, Wallet wallet)
    {
        Amount = amount;
        Wallet = wallet;
        DateTime = DateTime.UtcNow;
    }
    
    private Replenishment() {}
}