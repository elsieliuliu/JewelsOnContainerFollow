using CategoryAPI.Domain;

namespace CategoryAPI.ViewModels
{
    public class PaginatedItemsViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }
        public IEnumerable<CatelogueItem> Data { get; set; }
    }
}
