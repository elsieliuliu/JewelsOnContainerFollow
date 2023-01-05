using CategoryAPI.Data;
using CategoryAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CategoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _context;
        private readonly IConfiguration _config;
        public CatalogController(CatalogContext context, IConfiguration config) 
        { 
            _context = context;
            _config = config;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> CatelogTypes()
        {
            var types = await _context.CatelogTypes.ToListAsync();
            return Ok(types);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CatalogueBrands()
        {
            var brands = await _context.CatalogueBrands.ToListAsync();
            return Ok(brands);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery]int pageIndex = 0, [FromQuery]int pageSize = 6)
        {
            var items = await _context.CatelogueItems
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
            items = ChangePictureUrl(items);

            return Ok(items);

        }

        private List<CatelogueItem> ChangePictureUrl(List<CatelogueItem> items)
        {
            items.ForEach(item => item.PictureUrl
            .Replace("http://externalcatalogbaseurltobereplaced",
            _config["ExternalBaseUrl"]));

            return items;
        }
    }
}
