using CategoryAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace CategoryAPI.Data
{
    public class CatalogContext: DbContext
    {
        public CatalogContext(DbContextOptions options) : base(options) 
        { }
        

        public DbSet<CatelogType> CatelogTypes { get; set; }
        //table name is always plural  
        public DbSet<CatalogueBrand> CatalogueBrands { get; set; }
        public DbSet<CatelogueItem> CatelogueItems { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatelogType>(e =>
            {
                e.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(100);
            }
            );

            modelBuilder.Entity<CatalogueBrand>(e =>
            {
                e.Property(b => b.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(b => b.Brand)
                .IsRequired()
                .HasMaxLength(100);
            }
            );

            modelBuilder.Entity<CatelogueItem>(e =>
            {
                e.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(250);

                e.Property(c => c.Price)
                .IsRequired();

                e.HasOne(t => t.CatelogType).
                WithMany() //catelogtypes can have more relationships
                .HasForeignKey(t => t.CatalogTypeId);

                e.HasOne(t => t.CatalogueBrand)
                .WithMany()
                .HasForeignKey(t => t.CatalogBrandId);
            });

        }
    }
}
