namespace DesignPatternsWorkshop.Application.Strategies;

public class FixedDiscountStrategy : IDiscountStrategy
{
    private readonly double _discountValue;

    public string Name { get; set; } = "Fixed amount discount";

    public FixedDiscountStrategy(double discountValue)
    {
        _discountValue = discountValue;
    }

    public double ApplyDiscount(double totalAmount)
    {
        return totalAmount - _discountValue;
    }
}
