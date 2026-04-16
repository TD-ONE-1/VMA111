using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMS.Entity;
using RMS.Models.SecondApp;

namespace RMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SWADashboardController : Controller
    {
        private readonly RMSContext _context;
        private readonly IWebHostEnvironment _env;
        public SWADashboardController(RMSContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet, Route("GetDashboardCount")]
        public IActionResult GetDashboardCount()
        {
            var usrCount = _context.ProductCategories.Count();
            var shpkeprCount = _context.Shopkeepers.Count();
            var cstmerCount = _context.Customers.Count();
            var brnchCount = _context.ShopBranches.Count();
            var prdctCount = _context.Products.Count();
            var purPrdctCount = _context.ProductPurchases.Count();
            var ordrCount = _context.Orders.Count();

            DashboardModel model = new DashboardModel
            {
                UserCount = usrCount,
                ShopkeeperCount = shpkeprCount,
                CustomerCount = cstmerCount,
                BranchCount = brnchCount,
                ProductCount = prdctCount,
                PurchasedProductCount = purPrdctCount,
                OrderCount = ordrCount
            };

            return Ok(model);
        }
    }
}
