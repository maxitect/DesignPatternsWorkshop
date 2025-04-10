using DesignPatternsWorkshop.Application.DTOs;
using DesignPatternsWorkshop.Application.Strategies;
using DesignPatternsWorkshop.Domain.Strategies;

namespace DesignPatternsWorkshop.Application.Commands;

public record AddDiscountCommand : IPurchaseCommand
{
    #region properties
    private readonly IDiscountStrategy _discount;
    private readonly PurchaseDTO _purchase;
    #endregion

    #region constructor
    public AddDiscountCommand(PurchaseDTO purchase, IDiscountStrategy discount)
    {
        _discount = discount;
        _purchase = purchase;
    }
    #endregion

    #region methods
    public void Execute() => _purchase.SetDiscountStrategy(_discount);

    public void Revert()
    {
        var noDiscount = new NoDiscountStrategy();
        _purchase.SetDiscountStrategy(noDiscount);
    }
    #endregion
}
