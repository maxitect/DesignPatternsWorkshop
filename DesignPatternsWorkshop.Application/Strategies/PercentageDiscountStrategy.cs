using DesignPatternsWorkshop.Application.Strategies;

namespace DesignPatternsWorkshop.Infrastructure.Strategies;

public class PercentageDiscountStrategy : IDiscountStrategy
{
    private readonly double _percentage;

    public PercentageDiscountStrategy(double percentage)
    {
        _percentage = percentage;
    }

    public string Name { get; } = "Percentile discount";

    public double ApplyDiscount(double amount)
    {
        return amount - (amount * _percentage / 100);
    }
}
