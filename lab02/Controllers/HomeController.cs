using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using lab01.Models;
using lab01.Entities;
using Microsoft.EntityFrameworkCore;

namespace lab02.Controllers;

public class HomeController : Controller
{
  MyAppContext db;
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger, MyAppContext context)
  {
    _logger = logger;
    db = context;
  }

  public IActionResult Index()
  {
    return View();
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

