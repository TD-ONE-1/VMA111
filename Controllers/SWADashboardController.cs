using Microsoft.AspNetCore.Mvc;
using RMS.Entity;

namespace RMS.Controllers
{
    public class SWADashboardController : Controller
    {
        private readonly RMSContext _context;
        private readonly IWebHostEnvironment _env;
        public SWADashboardController(RMSContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
    }
}
