using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMS.Common.Helper;
using RMS.Entity;
using RMS.Models.SecondApp;

namespace RMS.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SWAReportsController : Controller
    {
        private readonly RMSContext _context;
        private readonly IWebHostEnvironment _env;
        public SWAReportsController(RMSContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet, Route("GetDashboardCounts")]
        public IActionResult GetDashboardCounts()
        {
            var result = new
            {
                ShopkeeperCount = _context.Shopkeepers.Count(),
                ShopBranchesCount = _context.ShopBranches.Count(),
                OrderCount = _context.Orders.Count(),
                CustomerCount = _context.Customers.Count(),
                ProductCount = _context.Products.Count()
            };

            return Ok(result);
        }

        [HttpGet, Route("GetShopsByStatus")]
        public IActionResult GetShopsByStatus(bool status)
        {
            var shps = _context.ShopBranches.Where(o => o.Status == status).ToList();

            var model = MapperHelper.MapList<ShopBranchModel, ShopBranch>(shps);

            return Ok(model);
        }

        [HttpGet, Route("GetOrdersByStatus")]
        public IActionResult GetOrdersByStatus(string status)
        {
            var orders = _context.Orders.Where(o => o.OrderStatus == status).ToList();

            var model = MapperHelper.MapList<OrdersModel, Order>(orders);

            return Ok(model);
        }

        [HttpGet, Route("GetOrdersByShopkeeperId")]
        public IActionResult GetOrdersByShopkeeperId(int ShopkeeperId)
        {
            var orders = _context.Orders.Where(o => o.ShopkeeperId == ShopkeeperId).ToList();

            var model = MapperHelper.MapList<OrdersModel, Order>(orders);

            return Ok(model);
        }

        [HttpGet, Route("GetOrdersByPayment")]
        public IActionResult GetOrdersByPayment(string paymentStatus)
        {
            List<Order> orders;

            if (paymentStatus == "Paid")
            {
                orders = _context.Orders.Where(o => !string.IsNullOrEmpty(o.DeliveryReceivedBy)).ToList();
            }
            else
            {
                orders = _context.Orders.Where(o => string.IsNullOrEmpty(o.DeliveryReceivedBy)).ToList();
            }

            var model = MapperHelper.MapList<OrdersModel, Order>(orders);

            return Ok(model);
        }

        [HttpGet, Route("GetShopkeeperByBussinessId")]
        public IActionResult GetShopkeeperByBussinessId(int BussinessId)
        {
            var shpkeeprs = _context.Shopkeepers.Where(o => o.BusinessTypeId == BussinessId).ToList();
            
            var model = MapperHelper.MapList<ShopkeeperModel, Shopkeeper>(shpkeeprs);

            return Ok(model);
        }

        [HttpGet, Route("GetOrdersByDateRange")]
        public IActionResult GetOrdersByDateRange(DateTime fromDate, DateTime toDate)
        {
            var startDate = fromDate.Date;
            var endDate = toDate.Date.AddDays(1).AddTicks(-1);

            var orders = _context.Orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).ToList();

            var model = MapperHelper.MapList<OrdersModel, Order>(orders);

            return Ok(model);
        }

        [HttpGet, Route("GetTopSellingProducts")]
        public IActionResult GetTopSellingProducts()
        {
            var result = _context.ProductPurchases
                .Where(p => p.TransactionType == "Sale")
                .GroupBy(p => p.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    TotalQuantitySold = g.Sum(x => x.Quantity),
                    TotalSalesAmount = g.Sum(x => x.Quantity * x.Price)
                })
                .OrderByDescending(x => x.TotalQuantitySold)
                .ToList();

            return Ok(result);
        }

        [HttpGet("GetRevenueByShopAndBranch")]
        public async Task<IActionResult> GetRevenueByShopAndBranch(DateTime fromDate, DateTime toDate)
        {
            var data = _context.Orders
                .Where(x =>
                    x.OrderStatus == "confirmed" &&
                    x.OrderDate >= fromDate &&
                    x.OrderDate <= toDate)
                .GroupBy(x => new
                {
                    x.ShopkeeperId,
                    x.BranchId
                })
                .Select(g => new
                {
                    ShopkeeperId = g.Key.ShopkeeperId,
                    BranchId = g.Key.BranchId,

                    TotalOrders = g.Count(),

                    TotalRevenue = g.Sum(x =>
                        x.Price - x.Discount),

                    TotalDiscount = g.Sum(x =>
                        x.Discount),

                    TotalCost = g.Sum(x =>
                        x.Cost),

                    Profit = g.Sum(x =>
                        (x.Price - x.Discount) - x.Cost)
                })
                .OrderByDescending(x => x.TotalRevenue)
                .ToList();

            return Ok(data);
        }

        [HttpGet("GetRevenueLast3MonthsByShopAndBranch")]
        public async Task<IActionResult> GetRevenueLast3MonthsByShopAndBranch()
        {
            DateTime startDate = DateTime.Now.AddMonths(-3);

            var data = _context.Orders
                .Where(x =>
                    x.OrderStatus == "confirmed" &&
                    x.OrderDate >= startDate)
                .GroupBy(x => new
                {
                    x.ShopkeeperId,
                    x.BranchId,
                    Year = x.OrderDate.Year,
                    Month = x.OrderDate.Month
                })
                .Select(g => new
                {
                    ShopkeeperId = g.Key.ShopkeeperId,

                    BranchId = g.Key.BranchId,

                    Year = g.Key.Year,

                    Month = g.Key.Month,

                    MonthName = new DateTime(
                        g.Key.Year,
                        g.Key.Month,
                        1).ToString("MMMM"),

                    TotalOrders = g.Count(),

                    TotalRevenue = g.Sum(x =>
                        x.Price - x.Discount),

                    TotalDiscount = g.Sum(x =>
                        x.Discount),

                    TotalCost = g.Sum(x =>
                        x.Cost),

                    Profit = g.Sum(x =>
                        (x.Price - x.Discount) - x.Cost)
                })
                .OrderBy(x => x.ShopkeeperId)
                .ThenBy(x => x.BranchId)
                .ThenBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToList();

            return Ok(data);
        }
    }
}
