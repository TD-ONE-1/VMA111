using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS.Common.Helper;
using RMS.Entity;
using RMS.Models;

namespace RMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly RMSContext _context;
        public DashboardController(RMSContext context)
        {
            _context = context;
        }

        [HttpGet, Route("GetReservationCountByUser")]
        public IActionResult GetReservationCountByUser(int UserId)
        {
            var data = _context.ReservationRequests
           .Where(x => x.UserId == UserId)
           .GroupBy(x => 1)
           .Select(g => new
           {
               Total = g.Count(),
               Confirmed = g.Count(x => x.Status == true),
               Pending = g.Count(x => x.Status == false)
           })
            .FirstOrDefault();

            DashboardModel model = new DashboardModel
            {
                TotalReservationCount = data?.Total ?? 0,
                ConfirmReservationCount = data?.Confirmed ?? 0,
                PendingReservationCount = data?.Pending ?? 0
            };

            return Ok(model);
        }
    }
}
