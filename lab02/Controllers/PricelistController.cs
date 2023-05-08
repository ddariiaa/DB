using System;
using lab01.Entities;
using lab02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab02.Controllers
{
  public class PricelistController : Controller
  {
    MyAppContext db;
    private readonly ILogger<PricelistController> _logger;

    public PricelistController(ILogger<PricelistController> logger, MyAppContext context)
    {
      _logger = logger;
      db = context;
    }

    public async Task<IActionResult> Select()
    {
      return View(new SelectViewModel { PricelistPositions = await db.PricelistPositions.ToListAsync() });
    }

    [HttpGet]
    public async Task<IActionResult> Insert()
    {
      return View(new InsertViewModel
      {
        PricelistPosition = new(),
        Trademarks = await db.Trademarks.ToListAsync(),
        Products = await db.Products.ToListAsync()
      });
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromForm] PricelistPosition pricelistPosition)
    {
      bool exists = await db.PricelistPositions.AnyAsync(p => p.KODPR == pricelistPosition.KODPR);
      if (ModelState.IsValid && !exists)
      {
        db.Add<PricelistPosition>(pricelistPosition);
        await db.SaveChangesAsync();
        return Redirect("/pricelist/select");
      }

      if (exists)
        TempData["KODPR"] = "Position with such KODPR already exists. Input another one";

      return this.Redirect(this.Request.Path.Value + this.Request.QueryString.Value);
    }

    [HttpGet]
    public async Task<IActionResult> Update()
    {
      return View(new UpdateViewModel
      {
        Trademarks = await db.Trademarks.ToListAsync(),
        Products = await db.Products.ToListAsync(),
        PricelistPositions = await db.PricelistPositions.ToListAsync()
      });
    }

    [HttpPost]
    public async Task<IActionResult> Update(int pricelistPositionId)
    {
      return View("_Update", new UpdatePartialViewModel
      {
        PricelistPosition = await db.PricelistPositions.FirstAsync(t => t.KODPR == pricelistPositionId),
        Trademarks = await db.Trademarks.ToListAsync(),
        Products = await db.Products.ToListAsync()
      });
    }

    [HttpPost]
    public async Task<IActionResult> UpdateConcrete([FromRoute] int id, [FromForm] PricelistPosition pricelistPosition)
    {
      PricelistPosition _pricelistPosition = await db.PricelistPositions.FirstAsync(t => t.KODPR == id);
      _pricelistPosition.KODTM = pricelistPosition.KODTM;
      _pricelistPosition.KODP = pricelistPosition.KODP;
      _pricelistPosition.CINA = pricelistPosition.CINA;

      db.Update<PricelistPosition>(_pricelistPosition);
      await db.SaveChangesAsync();

      return Redirect("/pricelist/select");
    }
  }
}

