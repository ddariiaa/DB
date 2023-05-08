using System;
using lab01.Entities;
using lab02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab02.Controllers
{
  public class RealizationController : Controller
  {
    MyAppContext db;
    private readonly ILogger<RealizationController> _logger;

    public RealizationController(ILogger<RealizationController> logger, MyAppContext context)
    {
      _logger = logger;
      db = context;
    }

    public async Task<IActionResult> Select()
    {
      return View(new SelectViewModel { Realizations = await db.Realizations.ToListAsync() });
    }

    [HttpGet]
    public async Task<IActionResult> Insert()
    {
      return View(new InsertViewModel
      {
        Realization = new(),
        Trademarks = await db.Trademarks.ToListAsync(),
        Products = await db.Products.ToListAsync(),
        Pricelist = await db.PricelistPositions.ToListAsync()
      });
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromForm] Realization realization)
    {
      if (ModelState.IsValid)
      {
        db.Add<Realization>(realization);
        await db.SaveChangesAsync();
        return Redirect("/realization/select");
      }

      return this.Redirect(this.Request.Path.Value + this.Request.QueryString.Value);
    }

    [HttpGet]
    public async Task<IActionResult> Update()
    {
      return View(new UpdateViewModel { Realizations = await db.Realizations.ToListAsync() });
    }

    [HttpPost]
    public async Task<IActionResult> Update(int realizationId)
    {
      return View("_Update", new UpdatePartialViewModel
      {
        Realization = await db.Realizations.FirstAsync(t => t.ID == realizationId),
        Trademarks = await db.Trademarks.ToListAsync(),
        Products = await db.Products.ToListAsync(),
        Pricelist = await db.PricelistPositions.ToListAsync()
      });
    }

    [HttpPost]
    public async Task<IActionResult> UpdateConcrete([FromRoute] int id, [FromForm] Realization realization)
    {
      Realization _realization = await db.Realizations.FirstAsync(t => t.ID == id);
      _realization.KODPR = realization.KODPR;
      _realization.KIL = realization.KIL;
      _realization.DATAR = realization.DATAR;
      _realization.DATAS = realization.DATAS;

      db.Update<Realization>(_realization);
      await db.SaveChangesAsync();

      return Redirect("/realization/select");
    }
  }
}

