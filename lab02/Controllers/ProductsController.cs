using System;
using lab01.Entities;
using lab02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab02.Controllers
{
  public class ProductsController : Controller
  {
    MyAppContext db;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger, MyAppContext context)
    {
      _logger = logger;
      db = context;
    }

    public async Task<IActionResult> Select()
    {
      return View(new SelectViewModel { Products = await db.Products.ToListAsync() });
    }

    [HttpGet]
    public async Task<IActionResult> Insert()
    {
      return View(new InsertViewModel { Product = new() });
    }

    [HttpPost]
    public async Task<IActionResult> Insert(Product product)
    {
      if (ModelState.IsValid)
      {
        if (string.IsNullOrWhiteSpace(product.NAMEP))
          return this.Redirect(this.Request.Path.Value + this.Request.QueryString.Value);

        db.Add<Product>(product);
        await db.SaveChangesAsync();
        return Redirect("/products/select");
      }

      return this.Redirect(this.Request.Path.Value + this.Request.QueryString.Value);
    }

    [HttpGet]
    public async Task<IActionResult> Update()
    {
      return View(new UpdateViewModel { Products = await db.Products.ToListAsync() });
    }

    [HttpPost]
    public async Task<IActionResult> Update(int productId)
    {
      return View("_Update", new UpdatePartialViewModel { Product = await db.Products.FirstAsync(t => t.KODP == productId) });
    }

    [HttpPost]
    public async Task<IActionResult> UpdateConcrete([FromRoute] int id, [FromForm] Product product)
    {
      Product _product = await db.Products.FirstAsync(t => t.KODP == id);
      _product.NAMEP = product.NAMEP;

      db.Update<Product>(_product);
      await db.SaveChangesAsync();

      return Redirect("/products/select");
    }
  }
}

