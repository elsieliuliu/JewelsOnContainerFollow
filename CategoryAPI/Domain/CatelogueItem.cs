namespace CategoryAPI.Domain
{
    public class CatelogueItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public int CatalogTypeId { get; set; }
        public int CatalogBrandId { get; set; }

        public virtual CatelogType CatelogType { get; set; }
        public virtual CatalogueBrand CatalogueBrand { get; set; }




    }
}
