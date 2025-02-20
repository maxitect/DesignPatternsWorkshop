using DesignPatternsWorkshop.Application.Strategies;
using DesignPatternsWorkshop.Domain.Strategies;

namespace DesignPatternsWorkshop.Domain.Models;

public class Purchase
{
    #region properties
    private IDiscountStrategy _discount;
    public int Id { get; set; }
    public List<Product> Products { get; set; } = new();
    #endregion

    #region constructor
    public Purchase()
    {
        _discount = new NoDiscountStrategy();
    }
    #endregion

    #region methods
    public void SetDiscountStrategy(IDiscountStrategy discount)
    {
        _discount = discount;
    }
    public double GetTotal()
    {
        double total = Products.Sum(p => p.Price * p.Quantity);

        return _discount.ApplyDiscount(total);
    }
    #endregion
}
