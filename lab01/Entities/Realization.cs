using System;
namespace lab01.Entities
{
  public class Realization
  {
    public int ID { get; set; }
    public int KODPR { get; set; }
    public int KIL { get; set; }
    public DateTime DATAR { get; set; }
    public DateTime? DATAS { get; set; }

    //public virtual PricelistPosition PricelistPosition { get; set; }
  }
}

