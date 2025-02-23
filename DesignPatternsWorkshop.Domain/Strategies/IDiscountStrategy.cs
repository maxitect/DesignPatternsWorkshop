namespace DesignPatternsWorkshop.Application.Strategies;

public interface IDiscountStrategy
{
    public string Name { get; }

    /// <summary>
    /// Applies the current discount stragety to the given total amount of a transaction.
    /// </summary>
    /// <param name="amount">Base total for a given transaction.</param>
    /// <returns>Final total for a transaction after the discount has been applied.</returns>
    public double ApplyDiscount(double amount);
}
