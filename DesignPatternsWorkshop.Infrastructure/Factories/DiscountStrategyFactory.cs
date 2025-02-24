using DesignPatternsWorkshop.Application.Strategies;
using DesignPatternsWorkshop.Infrastructure.Strategies;

namespace DesignPatternsWorkshop.Infrastructure.Factories;

public class DiscountStrategyFactory
{
    public IDiscountStrategy CreateDiscountStrategy(string discountStrategyName, double value)
    {
        switch (discountStrategyName)
        {
            case "percentile":
                return new PercentageDiscountStrategy(value);
            default:
                throw new ArgumentException("Invalid discount strategy identifier");
        }
    }
}
