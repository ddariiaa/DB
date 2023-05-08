using System;
using lab01.Entities;
using lab02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab02.Controllers
{
  public class TrademarksController : Controller
  {
    MyAppContext db;
    private readonly ILogger<TrademarksController> _logger;

    public TrademarksController(ILogger<TrademarksController> logger, MyAppContext context)
    {
      _logger = logger;
      db = context;
    }

    public async Task<IActionResult> Select()
    {
      return View(new SelectViewModel { Trademarks = await db.Trademarks.ToListAsync() });
    }

    [HttpGet]
    public async Task<IActionResult> Insert()
    {
      return View(new InsertViewModel { Trademark = new() });
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromForm] Trademark trademark)
    {
      if (ModelState.IsValid)
      {
        if (string.IsNullOrWhiteSpace(trademark.NAMETM))
          return this.Redirect(this.Request.Path.Value + this.Request.QueryString.Value);

        db.Add<Trademark>(trademark);
        await db.SaveChangesAsync();
        return Redirect("/trademarks/select");
      }

      return this.Redirect(this.Request.Path.Value + this.Request.QueryString.Value);
    }

    [HttpGet]
    public async Task<IActionResult> Update()
    {
      return View(new UpdateViewModel { Trademarks = await db.Trademarks.ToListAsync() });
    }

    [HttpPost]
    public async Task<IActionResult> Update(int trademarkId)
    {
      return View("_Update", new UpdatePartialViewModel { Trademark = await db.Trademarks.FirstAsync(t => t.KODTM == trademarkId) });
    }

    [HttpPost]
    public async Task<IActionResult> UpdateConcrete([FromRoute] int id, [FromForm] Trademark trademark)
    {
      Trademark _trademark = await db.Trademarks.FirstAsync(t => t.KODTM == id);
      _trademark.NAMETM = trademark.NAMETM;

      db.Update<Trademark>(_trademark);
      await db.SaveChangesAsync();

      return Redirect("/trademarks/select");
    }
  }
}

