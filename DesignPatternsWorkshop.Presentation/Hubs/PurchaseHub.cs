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

        await Clients.All.SendAsync("UpdatePurchase");
    }

    public async Task RemoveProduct(ProductDTO product)
    {
        _service.RemoveProduct(
            new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
            }
        );

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
}
