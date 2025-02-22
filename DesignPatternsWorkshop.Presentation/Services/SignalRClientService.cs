using DesignPatternsWorkshop.Application.DTOs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace DesignPatternsWorkshop.Presentation.Services;

public class SignalRClientService
{
    private readonly HubConnection _connection;
    public event Func<PurchaseDTO, Task>? PurchaseUpdate;

    public SignalRClientService()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5130/purchase-hub")
            .WithAutomaticReconnect()
            .Build();

        RegisterHandlers();
        _connection.StartAsync();
    }

    private void RegisterHandlers()
    {
        _connection.On<PurchaseDTO>(
            "UpdatePurchase",
            async (updatedPurchase) =>
            {
                if (PurchaseUpdate is not null)
                {
                    await PurchaseUpdate.Invoke(updatedPurchase);
                }
            }
        );
    }

    public async Task AddProductAsync(ProductDTO product)
    {
        await _connection.InvokeAsync("AddProduct", product);
    }
}
