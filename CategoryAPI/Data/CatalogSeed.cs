using CategoryAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CategoryAPI.Data
{
    public static class CatalogSeed
    {
        public static void Seed(CatalogContext context)
        {
            context.Database.Migrate();

            if (!context.CatelogTypes.Any())
            {
                context.CatelogTypes.AddRange(GetCatelogTypes());
                context.SaveChanges();
            }
            if (!context.CatalogueBrands.Any())
            {
                context.CatalogueBrands.AddRange(GetCatalogueBrands());
                context.SaveChanges();
            }
            if (!context.CatelogueItems.Any())
            {
                context.CatelogueItems.AddRange(GetCatelogueItems());
                context.SaveChanges();
            }
        }

        private static IEnumerable<CatelogueItem> GetCatelogueItems()
        {
            return new List<CatelogueItem>()
            {
                new CatelogueItem { CatalogTypeId = 2, CatalogBrandId = 3, Description = "A ring that has been around for over 100 years", Name = "World Star", Price = 199.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new CatelogueItem { CatalogTypeId = 1, CatalogBrandId = 2, Description = "will make you world champions", Name = "White Line", Price = 88.50M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new CatelogueItem { CatalogTypeId = 2, CatalogBrandId = 3, Description = "You have already won gold medal", Name = "Prism White", Price = 129, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" },
                new CatelogueItem { CatalogTypeId = 2, CatalogBrandId = 2, Description = "Olympic runner", Name = "Foundation Hitech", Price = 12, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4" },
                new CatelogueItem { CatalogTypeId = 2, CatalogBrandId = 1, Description = "Roslyn Red Sheet", Name = "Roslyn White", Price = 188.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new CatelogueItem { CatalogTypeId = 2, CatalogBrandId = 2, Description = "Lala Land", Name = "Blue Star", Price = 112, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6" },
                new CatelogueItem { CatalogTypeId = 2, CatalogBrandId = 1, Description = "High in the sky", Name = "Roslyn Green", Price = 212, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7" },
                new CatelogueItem { CatalogTypeId = 1, CatalogBrandId = 1, Description = "Light as carbon", Name = "Deep Purple", Price = 238.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8" },
                new CatelogueItem { CatalogTypeId = 1, CatalogBrandId = 2, Description = "High Jumper", Name = "Antique Ring", Price = 129, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9" },
                new CatelogueItem { CatalogTypeId = 2, CatalogBrandId = 3, Description = "Dunker", Name = "Elequent", Price = 12, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10" },
                new CatelogueItem { CatalogTypeId = 1, CatalogBrandId = 2, Description = "All round", Name = "Inredeible", Price = 248.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new CatelogueItem { CatalogTypeId = 2, CatalogBrandId = 1, Description = "Pricesless", Name = "London Sky", Price = 412, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12" },
                new CatelogueItem { CatalogTypeId = 3, CatalogBrandId = 3, Description = "You ar ethe star", Name = "Elequent", Price = 123, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13" },
                new CatelogueItem { CatalogTypeId = 3, CatalogBrandId = 2, Description = "A ring popular in the 16th and 17th century in Western Europe that was used as an engagement wedding ring", Name = "London Star", Price = 218.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14" },
                new CatelogueItem { CatalogTypeId = 3, CatalogBrandId = 1, Description = "A floppy, bendable ring made out of links of metal", Name = "Paris Blues", Price = 312, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15" }
            };
        }

        private static IEnumerable<CatalogueBrand> GetCatalogueBrands()
        {
            return new List<CatalogueBrand>
            {
                new CatalogueBrand{Brand="Tiffnany & Co."},
                new CatalogueBrand{Brand="DeBeers"},
                new CatalogueBrand{Brand="Graff"},

            };
        }

        private static IEnumerable<CatelogType> GetCatelogTypes()
        {
            return new List<CatelogType>
            {
                new CatelogType{Type="Engagement Ring"},
                new CatelogType{Type="Wedding Ring"},
                new CatelogType{Type="Fashion Ring"},

            };
        }
    }
}
