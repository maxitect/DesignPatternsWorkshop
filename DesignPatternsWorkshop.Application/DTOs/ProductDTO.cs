namespace DesignPatternsWorkshop.Application.DTOs;

public record ProductDTO
{
    #region properties
    public string Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    #endregion

    #region constructor
    public ProductDTO(string id, string name, double price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
    #endregion
}
