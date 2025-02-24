namespace DesignPatternsWorkshop.Application.Strategies;

public class BundleDiscountStrategy : IDiscountStrategy
{
    public string Name { get; set; } = "Bundle discount";

    private readonly double _discount;

    public BundleDiscountStrategy(double discount)
    {
        _discount = discount;
    }

    public double ApplyDiscount(double amount)
    {
        return amount - ((amount / 10) * _discount);
    }
}
