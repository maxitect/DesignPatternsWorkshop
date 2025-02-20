using DesignPatternsWorkshop.Domain.Models;

namespace DesignPatternsWorkshop.Application.Commands;

public record RemoveProductCommand(Purchase purchase, Product product) : IPurchaseCommand
{
    public void Execute() => purchase.Products.Remove(product);

    public void Revert() => purchase.Products.Add(product);
}
