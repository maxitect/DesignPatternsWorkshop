using DesignPatternsWorkshop.Application.Strategies;

namespace DesignPatternsWorkshop.Infrastructure.Strategies;

public class PercentageDiscountStrategy : IDiscountStrategy
{
    private readonly double _percentage;
    public PercentageDiscountStrategy(double percentage)
    {
        _percentage = percentage;
    }
    public double ApplyDiscount(double amount)
    {
        return (amount * _percentage / 100);
    }
}
