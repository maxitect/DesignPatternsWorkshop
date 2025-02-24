using DesignPatternsWorkshop.Application.Strategies;
using DesignPatternsWorkshop.Infrastructure.Strategies;

namespace DesignPatternsWorkshop.Infrastructure.Factories;

public class DiscountStrategyFactory
{
    public IDiscountStrategy CreateDiscountStrategy(string discountStrategyName, double value)
    {
        switch (discountStrategyName)
        {
            case "percentage":
                return new PercentageDiscountStrategy(value);
            case "fixed":
                return new FixedDiscountStrategy(value);
            case "bundle":
                return new BundleDiscountStrategy(value);
            default:
                throw new ArgumentException("Invalid discount strategy identifier");
        }
    }
}
