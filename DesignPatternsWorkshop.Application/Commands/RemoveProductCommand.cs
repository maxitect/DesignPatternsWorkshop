using DesignPatternsWorkshop.Domain.Models;

namespace DesignPatternsWorkshop.Application.Commands;

public record RemoveProductCommand : IPurchaseCommand
{
    #region properties
    private readonly Product _product;
    private readonly Purchase _purchase;
    #endregion

    #region constructor
    public RemoveProductCommand(Purchase purchase, Product product)
    {
        _product = purchase.Products.FirstOrDefault(p => p.Id == product.Id)!;
        _purchase = purchase;
    }
    #endregion

    #region methods
    public void Execute() => _purchase.Products.Remove(_product);

    public void Revert() => _purchase.Products.Add(_product);
    #endregion
}
