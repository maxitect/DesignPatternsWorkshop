using DesignPatternsWorkshop.Domain.Models;
using DesignPatternsWorkshop.Infrastructure.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsWorkshop.Infrastructure.Controllers;

[ApiController]
[Route("/[Controller]/[Action]")]
public class PurchaseController : Controller
{
    #region properties
    private PurchaseService _service;
    #endregion

    #region constructor
    public PurchaseController()
    {
        _service = new PurchaseService();
    }
    #endregion

    #region endpoints
    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        try
        {
            _service.AddProduct(product);
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
    #endregion
}
