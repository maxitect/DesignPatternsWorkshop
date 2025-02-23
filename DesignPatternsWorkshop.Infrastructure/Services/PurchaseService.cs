using DesignPatternsWorkshop.Application.Commands;
using DesignPatternsWorkshop.Application.DTOs;
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
        _purchase = new Purchase { Id = new Random().Next(), Products = new List<Product>() };
        _invoker = new PurchaseInvoker();
    }
    #endregion

    #region methods
    public PurchaseDTO GetPurchase()
    {
        List<ProductDTO> productsList = new();
        _purchase.Products.ForEach(p =>
        {
            var dto = new ProductDTO(p.Id, p.Name, p.Price, p.Quantity);
            productsList.Add(dto);
        });

        var purchaseDto = new PurchaseDTO(_purchase.Id, productsList, _purchase.GetDiscount());
        return purchaseDto;
    }

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
