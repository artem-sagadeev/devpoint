using Domain.Payments.Entities;

namespace Web.API.Controllers.Payments.DTOs;

public class ReplenishmentDto
{
    public int Id { get; set; }
    public int Amount { get; set; }

    public ReplenishmentDto(Replenishment replenishment)
    {
        Id = replenishment.Id;
        Amount = replenishment.Amount;
    }
}