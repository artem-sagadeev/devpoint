using Domain.Payments.Entities;

namespace Web.API.Controllers.Payments.DTOs;

public class WithdrawalDto
{
    public int Id { get; set; }
    public int Amount { get; set; }

    public WithdrawalDto(Withdrawal withdrawal)
    {
        Id = withdrawal.Id;
        Amount = withdrawal.Amount;
    }
}