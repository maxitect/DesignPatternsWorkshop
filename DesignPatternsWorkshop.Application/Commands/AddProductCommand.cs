using DesignPatternsWorkshop.Domain.Models;

namespace DesignPatternsWorkshop.Application.Commands;

public class AddProductCommand : IPurchaseCommand
{
    #region properties
    private readonly Purchase _purchase;
    private readonly Product _product;
    #endregion

    #region constructor
    public AddProductCommand(Purchase purchase, Product product)
    {
        _purchase = purchase;
        _product = product;
    }
    #endregion

    #region methods
    public void Execute()
    {
        _purchase.Products.Add(_product);
    }

    public void Revert()
    {
        _purchase.Products.Remove(_product);
    }
    #endregion
}
