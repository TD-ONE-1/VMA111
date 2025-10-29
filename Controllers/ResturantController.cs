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
    //[Authorize]
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
            if(ResturantId == 0)
                return Ok(new { success = false, message = "Resturant is required!" });

            List<ResturantConfigrationModel> model = new List<ResturantConfigrationModel>();
            model = MapperHelper.MapList<ResturantConfigrationModel, ResturantConfigration>(_context.ResturantConfigrations
                .Where(p => p.Status == true && p.ResturantId == ResturantId).ToList());

            return Ok(model);
        }

        [HttpPost("SaveResturant")]
        public IActionResult SaveResturant([FromBody] ResturantModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Description))
                    return Ok(new { success = false, message = "Description is required!" });
                
                var dupCheck = _context.Resturants.Where(x => x.Description.ToLower() == model.Description.ToLower()).FirstOrDefault();
                if (dupCheck != null)
                {
                    return Ok(new { success = false, message = "This Resturant is already present. Please add a different one!" });
                }
                if (model.Id == 0)
                {
                    _context.Resturants.Add(MapperHelper.Map<Resturant, ResturantModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.Resturants.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.Description = model.Description;
                        record.Status = model.Status;
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

        [HttpPost("SaveResturantOffer")]
        public IActionResult SaveResturantOffer([FromBody] ResturantOfferModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Description) || model.ResturantId == 0)
                {
                    return Ok("Description or Resturant is required!");
                }
                var dupCheck = _context.ResturantOffers.Where(x => x.Description.ToLower() == model.Description.ToLower() && x.ResturantId == model.ResturantId).FirstOrDefault();
                if (dupCheck != null)
                {
                    return Ok(new { success = false, message = "This Resturant Offer is already present. Please add a different one!" });
                }
                if (model.Id == 0)
                {
                    _context.ResturantOffers.Add(MapperHelper.Map<ResturantOffer, ResturantOfferModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.ResturantOffers.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.Description = model.Description;
                        record.ResturantId = model.ResturantId;
                        record.Status = model.Status;
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
