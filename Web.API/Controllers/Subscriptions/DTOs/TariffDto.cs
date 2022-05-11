using Domain.Subscriptions.Entities;

namespace Web.API.Controllers.Subscriptions.DTOs;

public class TariffDto
{
    public int Id { get; set; }
    public int PricePerMonth { get; set; }
    public SubscriptionType SubscriptionType { get; set; }

    public TariffDto(Tariff tariff)
    {
        Id = tariff.Id;
        PricePerMonth = tariff.PricePerMonth;
        SubscriptionType = tariff.SubscriptionType;
    }
}