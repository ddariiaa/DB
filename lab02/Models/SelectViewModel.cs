﻿using System;
using lab01.Entities;

namespace lab02.Models
{
  public class SelectViewModel
  {
    public IEnumerable<Trademark> Trademarks { get; set; }
    public IEnumerable<Product> Products { get; set; }
    public IEnumerable<PricelistPosition> PricelistPositions { get; set; }
    public IEnumerable<Realization> Realizations { get; set; }
  }
}

