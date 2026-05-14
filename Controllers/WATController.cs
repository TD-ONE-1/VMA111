using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RMS.Common.Helper;
using RMS.Entity;
using RMS.Models.SecondApp;

namespace RMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WATController : Controller
    {
        private readonly RMSContext _context;
        private readonly IWebHostEnvironment _env;
        public WATController(RMSContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        
        [HttpGet, Route("GetShopBranches")]
        public IActionResult GetShopBranches()
        {
            List<ShopBranchModel> model = new List<ShopBranchModel>();
            model = MapperHelper.MapList<ShopBranchModel, ShopBranch>(_context.ShopBranches.Where(p => p.Status == true).ToList());

            return Ok(model);
        }

        [HttpGet, Route("GetShopkeepers")]
        public IActionResult GetShopkeepers()
        {
            List<ShopkeeperModel> model = new List<ShopkeeperModel>();
            model = MapperHelper.MapList<ShopkeeperModel, Shopkeeper>(_context.Shopkeepers.Where(p => p.Status == true).ToList());

            return Ok(model);
        }
    }
}
