using DesignPatternsWorkshop.Domain.Models;

namespace DesignPatternsWorkshop.Application.Commands;

public record AddProductCommand(Purchase purchase, Product product) : IPurchaseCommand
{
    public void Execute() => purchase.Products.Add(product);

    public void Revert() => purchase.Products.Remove(product);
}
