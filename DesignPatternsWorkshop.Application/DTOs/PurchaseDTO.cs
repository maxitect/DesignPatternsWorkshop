
using DesignPatternsWorkshop.Application.Strategies;

namespace DesignPatternsWorkshop.Application.DTOs;

public record PurchaseDTO(int Id, List<ProductDTO> Products, IDiscountStrategy? Discount);
