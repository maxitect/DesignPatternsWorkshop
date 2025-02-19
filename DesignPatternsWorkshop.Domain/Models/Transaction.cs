namespace DesignPatternsWorkshop.Domain.Models;

public class Transaction
{
    public int Id { get; set; }
    public List<Product> Products { get; set; }
    public decimal GetTotal()
    {
        decimal total = Products.Sum(p => p.Price * p.Quantity);
        return total;
    }
}
