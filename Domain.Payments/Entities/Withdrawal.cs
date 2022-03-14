namespace Domain.Payments.Entities;

public class Withdrawal
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public Wallet Wallet { get; set; }
    
    public Withdrawal(int id, int amount, Wallet wallet)
    {
        Id = id;
        Amount = amount;
        Wallet = wallet;
    }
}