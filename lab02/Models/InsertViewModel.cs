using System;
using lab01.Entities;

namespace lab02.Models
{
  public class InsertViewModel
  {
    public Trademark Trademark { get; set; }
    public Product Product { get; set; }
    public PricelistPosition PricelistPosition { get; set; }
    public Realization Realization { get; set; }

    public IEnumerable<Trademark> Trademarks { get; set; }
    public IEnumerable<Product> Products { get; set; }
    public IEnumerable<PricelistPosition> Pricelist { get; set; }
  }
}

