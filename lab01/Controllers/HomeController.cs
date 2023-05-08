using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab01.Models;
using lab01.Entities;
using Microsoft.EntityFrameworkCore;

namespace lab01.Controllers;

[Area("lab01")]
public class HomeController : Controller
{
  MyAppContext db;
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger, MyAppContext context)
  {
    _logger = logger;
    db = context;
  }

  public async Task<IActionResult> Index()
  {
    return View(new IndexViewModel
    {
      Trademarks = await db.Trademarks.ToListAsync(),
      Products = await db.Products.ToListAsync(),
      PricelistPositions = await db.PricelistPositions.ToListAsync(),
      Realizations = await db.Realizations.ToListAsync()
    });
  }

  public IActionResult Privacy()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}

