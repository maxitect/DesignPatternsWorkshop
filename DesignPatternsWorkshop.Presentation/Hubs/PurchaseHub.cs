using DesignPatternsWorkshop.Application.DTOs;
using DesignPatternsWorkshop.Domain.Models;
using DesignPatternsWorkshop.Infrastructure.Services;
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
        _service.AddProduct(
            new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
            }
        );

        var updatedPurchase = _service.GetPurchase();
        await Clients.All.SendAsync("UpdatePurchase", updatedPurchase);
    }

    public async Task Undo()
    {
        _service.UndoLastAction();
        var updatedPurchase = _service.GetPurchase();
        await Clients.All.SendAsync("UpdatePurchase", updatedPurchase);
    }

    public async Task Redo()
    {
        _service.RedoLastAction();

        var updatedPurchase = _service.GetPurchase();
        await Clients.All.SendAsync("UpdatePurchase", updatedPurchase);
    }
}
