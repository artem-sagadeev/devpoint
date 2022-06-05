using Domain.Subscriptions.Entities;

namespace Services.Subscriptions.Tariffs;

public interface ITariffService
{
    public Task<List<Tariff>> GetAllTariffs();

    public Task<List<Tariff>> GetTariffs(List<int> tariffIds);

    public Task<Tariff> GetTariff(int tariffId);

    public Task<SubscriptionLevel> GetTariffSubscriptionLevel(int tariffId);

    public Task<int> CreateTariff(int pricePerMonth, SubscriptionType subscriptionType, int subscriptionLevelId);

    public Task UpdatePricePerMonth(int tariffId, int pricePerMonth);
}