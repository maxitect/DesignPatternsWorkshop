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
