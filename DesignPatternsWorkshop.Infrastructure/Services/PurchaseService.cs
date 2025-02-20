using DesignPatternsWorkshop.Application.Commands;
using DesignPatternsWorkshop.Application.Strategies;
using DesignPatternsWorkshop.Domain.Models;
using DesignPatternsWorkshop.Infrastructure.Commands;

namespace DesignPatternsWorkshop.Infrastructure.Services;

public class PurchaseService
{
    #region properties
    private readonly Purchase _purchase;
    private readonly PurchaseInvoker _invoker;
    #endregion

    #region constructor
    public PurchaseService()
    {
        _purchase = new Purchase();
        _invoker = new PurchaseInvoker();
    }
    #endregion

    #region methods
    public Purchase FinalisePurchase() => _purchase;

    public void AddProduct(Product product)
    {
        var command = new AddProductCommand(_purchase, product);
        _invoker.ExecuteCommand(command);
    }

    public void RemoveProduct(Product product)
    {
        var command = new RemoveProductCommand(_purchase, product);
        _invoker.ExecuteCommand(command);
    }

    public void UndoLastAction()
    {
        _invoker.Undo();
    }

    public void RedoLastAction()
    {
        _invoker.Redo();
    }

    public void ApplyDiscount(IDiscountStrategy discount)
    {
        _purchase.SetDiscountStrategy(discount);
    }

    public double CalculateTotal()
    {
        var total = _purchase.GetTotal();
        return total;
    }
    #endregion
}
