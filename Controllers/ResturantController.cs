using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using RMS.Common.Helper;
using RMS.Entity;
using RMS.Models;

namespace RMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private readonly RMSContext _context;
        public ResturantController(RMSContext context)
        {
            _context = context;
        }

        [HttpGet, Route("GetResturants")]
        public IActionResult GetResturants()
        {
            List<ResturantModel> model = new List<ResturantModel>();
            model = MapperHelper.MapList<ResturantModel, Resturant>(_context.Resturants.Where(p => p.Status == true).ToList());

            return Ok(model);
        }

        [HttpGet, Route("GetResturantOffer")]
        public IActionResult GetResturantOffer()
        {
            List<ResturantOfferModel> model = new List<ResturantOfferModel>();
            model = MapperHelper.MapList<ResturantOfferModel, ResturantOffer>(_context.ResturantOffers.Where(p => p.Status == true).ToList());

            return Ok(model);
        }

        [HttpGet, Route("GetResturantConfigurationByResturantId")]
        public IActionResult GetResturantConfigurationByResturantId(int ResturantId)
        {
            List<ResturantConfigrationModel> model = new List<ResturantConfigrationModel>();
            model = MapperHelper.MapList<ResturantConfigrationModel, ResturantConfigration>(_context.ResturantConfigrations
                .Where(p => p.Status == true && p.ResturantId == ResturantId).ToList());

            return Ok(model);
        }

        [HttpPost("SaveResturantConfiguration")]
        public IActionResult SaveResturantConfiguration([FromBody] ResturantConfigrationModel conf)
        {
            try
            {
                if (conf.ResturantId == 0 || conf.OfferId == 0)
                {
                    return Ok("Resturant or Offer is required!");
                }
                if (conf.Id == 0)
                {                    
                    _context.ResturantConfigrations.Add(MapperHelper.Map<ResturantConfigration, ResturantConfigrationModel>(conf));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (conf.Id != 0)
                {
                    var record = _context.ResturantConfigrations.FirstOrDefault(p => p.Id == conf.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (conf.ResturantId == 0 || conf.OfferId == 0)
                    {
                        return Ok("Resturant or Offer is required!");
                    }

                    if (record != null)
                    {
                        record.ResturantId = conf.ResturantId;
                        record.OfferId = conf.OfferId;
                        record.Day = conf.Day;
                        record.From = conf.From;
                        record.To = conf.To;
                        record.Slot = conf.Slot;
                        record.Capacity = conf.Capacity;
                        record.Interval = conf.Interval;
                        record.Status = conf.Status;
                    };

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Updated successfully!" });
                }
                return Ok(new { success = false, message = "No action found!" });
            }
            catch (Exception)
            {
                return Ok("Something went wrong!");
            }
        }
    }
}
