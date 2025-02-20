using DesignPatternsWorkshop.Application.Strategies;

namespace DesignPatternsWorkshop.Infrastructure.Strategies;

public class PercentageDiscountStrategy : IDiscountStrategy
{
    private readonly decimal _percentage;
    public PercentageDiscountStrategy(decimal percentage)
    {
        _percentage = percentage;
    }
    public decimal ApplyDiscount(decimal amount)
    {
        return (amount * _percentage / 100);
    }
}
