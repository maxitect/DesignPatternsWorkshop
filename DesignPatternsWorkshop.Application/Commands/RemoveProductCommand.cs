using DesignPatternsWorkshop.Application.DTOs;

namespace DesignPatternsWorkshop.Application.Commands;

public record RemoveProductCommand : IPurchaseCommand
{
    #region properties
    private readonly ProductDTO _product;
    private readonly PurchaseDTO _purchase;
    #endregion

    #region constructor
    public RemoveProductCommand(PurchaseDTO purchase, ProductDTO product)
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
