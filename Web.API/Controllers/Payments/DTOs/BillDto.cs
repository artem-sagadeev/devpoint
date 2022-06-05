using Domain.Payments.Entities;

namespace Web.API.Controllers.Payments.DTOs;

public class BillDto
{
    public int Id { get; set; }
    public int Amount { get; set; }

    public BillDto(Bill bill)
    {
        Id = bill.Id;
        Amount = bill.Amount;
    }
}