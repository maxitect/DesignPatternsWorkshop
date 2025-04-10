using DesignPatternsWorkshop.Application.Decorators;
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
            case "birthday-percentage":
                return new BirthdayDiscountDecorator(new PercentageDiscountStrategy(value), new DateTime(2015, 04, 10));
            case "birthday-fixed":
                return new BirthdayDiscountDecorator(new FixedDiscountStrategy(value), new DateTime(2015, 04, 10));
            case "birthday-bundle":
                return new BirthdayDiscountDecorator(new BundleDiscountStrategy(value), new DateTime(2015, 10, 25));
            default:
                throw new ArgumentException("Invalid discount strategy identifier");
        }
    }
}
