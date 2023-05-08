using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab01.Entities
{
  public class Product
  {
    //[Column("blog_id")]
    public int KODP { get; set; }
    public string NAMEP { get; set; }
  }
}

