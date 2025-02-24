namespace DesignPatternsWorkshop.Application.Strategies;

public class FixedDiscountStrategy : IDiscountStrategy
{
    private readonly double _discountValue;

    public string Name { get; set; } = "Fixed amount discount";

    public FixedDiscountStrategy(double dicountValue)
    {
        _discountValue = dicountValue;
    }

    public double ApplyDiscount(double totalAmount)
    {
        return totalAmount - _discountValue;
    }
}
