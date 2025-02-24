using DesignPatternsWorkshop.Application.Strategies;
using DesignPatternsWorkshop.Domain.Strategies;

namespace DesignPatternsWorkshop.Domain.Models;

public class Purchase
{
    #region properties
    public int Id { get; set; }
    public List<Product> Products { get; set; }
    public IDiscountStrategy Discount;
    #endregion

    #region constructor
    public Purchase(int id, List<Product> products, IDiscountStrategy discount)
    {
        Id = id;
        Products = products;
        Discount = discount;
    }
    #endregion
}
