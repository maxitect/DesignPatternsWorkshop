using DesignPatternsWorkshop.Application.DTOs;
using DesignPatternsWorkshop.Domain.Models;
using DesignPatternsWorkshop.Infrastructure.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsWorkshop.Infrastructure.Controllers;

public class HomeController : Controller
{
    #region properties
    private PurchaseService _service;
    #endregion

    #region constructor
    public HomeController(PurchaseService service)
    {
        _service = service;
    }
    #endregion

    #region endpoints
    [HttpPost]
    public IActionResult AddProduct(ProductDTO product)
    {
        try
        {
            var newProduct = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
            };
            _service.AddProduct(newProduct);
            return Ok(product);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult UndoAction()
    {
        try
        {
            _service.UndoLastAction();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetPurchaseTotal()
    {
        try
        {
            double total = _service.CalculateTotal();
            return Ok(total);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult RedoAction()
    {
        try
        {
            _service.RedoLastAction();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult Index()
    {
        try
        {
            PurchaseDTO purchase = _service.GetPurchase();
            return View(purchase);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    #endregion
}
