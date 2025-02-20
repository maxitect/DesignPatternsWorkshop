using DesignPatternsWorkshop.Application.Strategies;
using DesignPatternsWorkshop.Domain.Strategies;

namespace DesignPatternsWorkshop.Domain.Models;

public class Purchase
{
    #region properties
    private IDiscountStrategy _discount;
    public int Id { get; set; }
    public List<Product> Products { get; set; }
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
    public decimal GetTotal()
    {
        decimal total = Products.Sum(p => p.Price * p.Quantity);

        return _discount.ApplyDiscount(total);
    }
    #endregion
}
