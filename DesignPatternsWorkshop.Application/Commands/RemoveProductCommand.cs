using DesignPatternsWorkshop.Domain.Models;

namespace DesignPatternsWorkshop.Application.Commands;

public class RemoveProductCommand : IPurchaseCommand
{
    #region properties
    private readonly Purchase _purchase;
    private readonly Product _product;
    #endregion

    #region constructor
    public RemoveProductCommand(Purchase purchase, Product product)
    {
        _purchase = purchase;
        _product = product;
    }
    #endregion

    #region methods
    public void Execute()
    {
        _purchase.Products.Remove(_product);
    }

    public void Undo()
    {
        _purchase.Products.Add(_product);
    }
    #endregion
}
