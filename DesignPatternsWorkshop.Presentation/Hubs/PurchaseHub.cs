using DesignPatternsWorkshop.Application.DTOs;
using DesignPatternsWorkshop.Application.Strategies;
using DesignPatternsWorkshop.Infrastructure.Services;
using DesignPatternsWorkshop.Infrastructure.Strategies;
using Microsoft.AspNetCore.SignalR;

namespace DesignPatternsWorkshop.Presentation.Hubs;

public class PurchaseHub : Hub
{
    private PurchaseService _service;

    public PurchaseHub(PurchaseService service)
    {
        _service = service;
    }

    public async Task AddProduct(ProductDTO product)
    {
        _service.AddProduct(product);

        await Clients.All.SendAsync("UpdatePurchase");
    }

    public async Task RemoveProduct(ProductDTO product)
    {
        _service.RemoveProduct(product);

        await Clients.All.SendAsync("UpdatePurchase");
    }

    public async Task Undo()
    {
        _service.UndoLastAction();

        await Clients.All.SendAsync("UpdatePurchase");
    }

    public async Task Redo()
    {
        _service.RedoLastAction();

        await Clients.All.SendAsync("UpdatePurchase");
    }

    public async Task AddDiscount()
    {
        _service.ApplyDiscount(new PercentageDiscountStrategy(15));
        await Clients.All.SendAsync("UpdatePurchase");
    }
}
