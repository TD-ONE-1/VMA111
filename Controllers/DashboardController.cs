using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS.Common.Helper;
using RMS.Entity;
using RMS.Models;

namespace RMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly RMSContext _context;
        public DashboardController(RMSContext context)
        {
            _context = context;
        }

        [HttpGet, Route("GetDashboardCount")]
        public IActionResult GetDashboardCount()
        {
            var eidRes = _context.EidReservations.Count();
            var res = _context.ReservationRequests
           .GroupBy(x => 1)
           .Select(g => new
           {
               Total = g.Count(),
               Cancelled = g.Count(x => x.Status == 2),
               Confirmed = g.Count(x => x.Status == 1),
               Pending = g.Count(x => x.Status == 0)
           })
            .FirstOrDefault();

            var eq = _context.EventQueries
          .GroupBy(x => 1)
          .Select(g => new
          {
              Total = g.Count(),
              Cancelled = g.Count(x => x.Status == 2),
              Confirmed = g.Count(x => x.Status == 1),
              Pending = g.Count(x => x.Status == 0)
          })
           .FirstOrDefault();

            var rev = _context.Reviews.Count();

            DashboardModel model = new DashboardModel
            {
                TotalReservationCount = res?.Total ?? 0,
                CancelledReservationCount = res?.Cancelled ?? 0,
                ConfirmedReservationCount = res?.Confirmed ?? 0,
                PendingReservationCount = res?.Pending ?? 0,
                TotalEventQueryCount = eq?.Total ?? 0,
                ConfirmedEventQueryCount = eq?.Confirmed ?? 0,
                PendingEventQueryCount = eq?.Pending ?? 0,
                CancelledEventQueryCount = eq?.Cancelled ?? 0,
                ReviewsCount = rev,
                EidReservationCount = eidRes
            };

            return Ok(model);
        }

        [HttpGet, Route("GetReservationCountByRestaurantId")]
        public IActionResult GetReservationCountByRestaurantId(int RestaurantId)
        {
            var data = _context.ReservationRequests
           .Where(x => x.RestaurantId == RestaurantId)
           .GroupBy(x => 1)
           .Select(g => new
           {
               Total = g.Count(),
               Cancelled = g.Count(x => x.Status == 2),
               Confirmed = g.Count(x => x.Status == 1),
               Pending = g.Count(x => x.Status == 0)
           })
            .FirstOrDefault();

            DashboardModel model = new DashboardModel
            {
                TotalReservationCount = data?.Total ?? 0,
                CancelledReservationCount = data?.Cancelled ?? 0,
                ConfirmedReservationCount = data?.Confirmed ?? 0,
                PendingReservationCount = data?.Pending ?? 0
            };

            return Ok(model);
        }

        [HttpGet, Route("GetReservationCountByUserId")]
        public IActionResult GetReservationCountByUserId(int UserId)
        {
            var data = _context.ReservationRequests
           .Where(x => x.UserId == UserId)
           .GroupBy(x => 1)
           .Select(g => new
           {
               Total = g.Count(),
               Cancelled = g.Count(x => x.Status == 2),
               Confirmed = g.Count(x => x.Status == 1),
               Pending = g.Count(x => x.Status == 0)
           })
            .FirstOrDefault();

            DashboardModel model = new DashboardModel
            {
                TotalReservationCount = data?.Total ?? 0,
                CancelledReservationCount = data?.Cancelled ?? 0,
                ConfirmedReservationCount = data?.Confirmed ?? 0,
                PendingReservationCount = data?.Pending ?? 0
            };

            return Ok(model);
        }

        [HttpGet, Route("GetReservationDateByRestaurantIdandStatus")]
        public IActionResult GetReservationDateByRestaurantIdandStatus(int RestaurantId, int Status)
        {
            var model = _context.ReservationRequests.Where(x => x.UserId == RestaurantId && x.Status == Status)
            .Select(x => x.ReservationDate.ToString("yyyy-MM-dd"))
            .ToList();

            return Ok(model);
        }

        [HttpGet, Route("GetReservationDatesByStatus")]
        public IActionResult GetReservationDatesByStatus(int Status)
        {
            var model = _context.ReservationRequests
            .Where(x => x.Status == Status)
            .Select(x => x.ReservationDate.ToString("yyyy-MM-dd"))
            .ToList();

            return Ok(model);
        }

        [HttpGet, Route("GetReservationDateByUserandStatus")]
        public IActionResult GetReservationDateByUser(int UserId, int Status)
        {
            var model = _context.ReservationRequests.Where(x => x.UserId == UserId && x.Status == Status)
             .Select(x => x.ReservationDate.ToString("yyyy-MM-dd"))
             .ToList();

            return Ok(model);
        }

        [HttpGet, Route("GetTop10ConfirmedReservation")]
        public IActionResult GetTop10ConfirmedReservation()
        {
            List<vwReservationModel> model = new List<vwReservationModel>();
            model = MapperHelper.MapList<vwReservationModel, vwReservation>(_context.vwReservations.Where(p => p.Status == 1).OrderByDescending(p => p.id).Take(10).ToList());

            return Ok(model);
        }
    }
}
