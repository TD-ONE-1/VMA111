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

        [HttpGet, Route("GetReservationCount")]
        public IActionResult GetReservationCount()
        {
            var data = _context.ReservationRequests
           .GroupBy(x => 1)
           .Select(g => new
           {
               Total = g.Count(),
               Confirmed = g.Count(x => x.Status == 1),
               Pending = g.Count(x => x.Status == 0)
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

        [HttpGet, Route("GetReservationCountByRestaurantId")]
        public IActionResult GetReservationCountByRestaurantId(int RestaurantId)
        {
            var data = _context.ReservationRequests
           .Where(x => x.RestaurantId == RestaurantId)
           .GroupBy(x => 1)
           .Select(g => new
           {
               Total = g.Count(),
               Confirmed = g.Count(x => x.Status == 1),
               Pending = g.Count(x => x.Status == 0)
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

        [HttpGet, Route("GetReservationCountByUserId")]
        public IActionResult GetReservationCountByUserId(int UserId)
        {
            var data = _context.ReservationRequests
           .Where(x => x.UserId == UserId)
           .GroupBy(x => 1)
           .Select(g => new
           {
               Total = g.Count(),
               Confirmed = g.Count(x => x.Status == 1),
               Pending = g.Count(x => x.Status == 0)
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

        [HttpGet, Route("GetReservationDateByRestaurantIdandStatus")]
        public IActionResult GetReservationDateByRestaurantIdandStatus(int RestaurantId, int Status)
        {
            var model = _context.ReservationRequests.Where(x => x.UserId == RestaurantId && x.Status == Status)
             .Select(x => new ReservationRequestModel
             {
                 Id = x.Id,
                 ReservationDate = x.ReservationDate
             }).ToList();

            return Ok(model);
        }

        [HttpGet, Route("GetReservationDatesByStatus")]
        public IActionResult GetReservationDatesByStatus(int Status)
        {
            var model = _context.ReservationRequests.Where(x => x.Status == Status)
             .Select(x => new ReservationRequestModel
             {
                 Id = x.Id,
                 ReservationDate = x.ReservationDate
             }).ToList();

            return Ok(model);
        }

        [HttpGet, Route("GetReservationDateByUserandStatus")]
        public IActionResult GetReservationDateByUser(int UserId, int Status)
        {
            var model = _context.ReservationRequests.Where(x => x.UserId == UserId && x.Status == Status)
             .Select(x => new ReservationRequestModel
             {
                 Id = x.Id,
                 ReservationDate = x.ReservationDate
             }).ToList();

            return Ok(model);
        }
    }
}
