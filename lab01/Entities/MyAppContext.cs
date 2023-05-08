using System;
using Microsoft.EntityFrameworkCore;

namespace lab01.Entities
{
  public class MyAppContext : DbContext
  {
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Trademark> Trademarks { get; set; }
    public virtual DbSet<PricelistPosition> PricelistPositions { get; set; }
    public virtual DbSet<Realization> Realizations { get; set; }
    public virtual DbSet<User> Users { get; set; }

    public MyAppContext(DbContextOptions<MyAppContext> options)
            : base(options)
    {
      Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Product>(product =>
      {
        product.HasKey(e => e.KODP);
        product.ToTable("ProductHandbook");
      });

      builder.Entity<Trademark>(trademark =>
      {
        trademark.HasKey(e => e.KODTM);
        trademark.ToTable("TMHandbook");
      });

      builder.Entity<PricelistPosition>(position =>
      {
        position.HasKey(e => e.KODPR);
        position.ToTable("PriceList");
      });

      builder.Entity<Realization>(realization =>
      {
        realization.HasKey(e => e.ID);
        realization.ToTable("Realisation");
      });

      builder.Entity<User>(user =>
      {
        user.HasKey(e => e.Id);
        user.ToTable("Users");
      });
    }
  }
}

