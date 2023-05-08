using System;
using lab01.Entities;

namespace lab02.Models
{
  public class UpdateViewModel
  {
    public IEnumerable<Trademark> Trademarks { get; set; }
    public IEnumerable<Product> Products { get; set; }
    public IEnumerable<PricelistPosition> PricelistPositions { get; set; }
    public IEnumerable<Realization> Realizations { get; set; }

    public int? TrademarkId { get; set; }
    public int? ProductId { get; set; }
    public int? PricelistPositionId { get; set; }
    public int? RealizationId { get; set; }
  }
}

