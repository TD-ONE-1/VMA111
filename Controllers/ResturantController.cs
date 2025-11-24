using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.CodeAnalysis.Operations;
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

        [HttpPost("SaveResturant")]
        public IActionResult SaveResturant([FromBody] ResturantModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                    return Ok(new { success = false, message = "Name is required!" });

                var dupCheck = _context.Restaurants.Where(x => x.Name.ToLower() == model.Name.ToLower() && x.Status == true).FirstOrDefault();
                if (dupCheck != null)
                {
                    return Ok(new { success = false, message = "This Resturant is already present. Please add a different one!" });
                }
                if (model.Id == 0)
                {
                    _context.Restaurants.Add(MapperHelper.Map<Restaurant, ResturantModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.Restaurants.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.Name = model.Name;
                        record.Location = model.Location;
                        record.OpeningTime = model.OpeningTime;
                        record.ClosingTime = model.ClosingTime;
                        record.Status = model.Status;
                    }
                    ;

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

        [HttpGet, Route("GetResturants")]
        public IActionResult GetResturants()
        {
            List<ResturantModel> model = new List<ResturantModel>();
            model = MapperHelper.MapList<ResturantModel, Restaurant>(_context.Restaurants.Where(p => p.Status == true).ToList());

            return Ok(model);
        }

        [HttpPost("SaveR_BookingType")]
        public IActionResult SaveR_BookingType([FromBody] R_BookingTypeModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                    return Ok(new { success = false, message = "Name is required!" });

                if (model.RestaurantId == 0 && model.BranchId == 0)
                    return Ok(new { success = false, message = "Resturant and Branch are required!" });

                var dupCheck = _context.R_BookingTypes.Where(x => x.Name.ToLower() == model.Name.ToLower() && x.IsActive == true && x.BranchId == model.BranchId && x.RestaurantId == model.RestaurantId).FirstOrDefault();
                if (dupCheck != null)
                {
                    return Ok(new { success = false, message = "This Booking Type is already present. Please add a different one!" });
                }
                if (model.Id == 0)
                {
                    _context.R_BookingTypes.Add(MapperHelper.Map<R_BookingType, R_BookingTypeModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.R_BookingTypes.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.Name = model.Name;
                        record.RestaurantId = model.RestaurantId;
                        record.BranchId = model.BranchId;
                        record.IsActive = model.IsActive;
                    }
                    ;

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

        [HttpGet, Route("GetR_BookingTypes")]
        public IActionResult GetR_BookingTypes()
        {
            List<R_BookingTypeModel> model = new List<R_BookingTypeModel>();
            model = MapperHelper.MapList<R_BookingTypeModel, R_BookingType>(_context.R_BookingTypes.Where(p => p.IsActive == true).ToList());

            return Ok(model);
        }

        [HttpGet, Route("GetR_BookingTypesByResturandandBranch")]
        public IActionResult GetR_BookingTypesByResturandandBranch(int RestaurantId, int BranchId)
        {
            if (RestaurantId == 0 || BranchId == 0)
                return Ok(new { success = false, message = "Resturant and Branch is required!" });

            List<R_BookingTypeModel> model = new List<R_BookingTypeModel>();
            model = MapperHelper.MapList<R_BookingTypeModel, R_BookingType>(_context.R_BookingTypes.Where(p => p.IsActive == true
                && p.RestaurantId == RestaurantId && p.BranchId == BranchId).ToList());

            return Ok(model);
        }

        [HttpPost("SaveR_Branch")]
        public IActionResult SaveR_Branch([FromBody] R_BranchModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                    return Ok(new { success = false, message = "Name is required!" });

                if (model.RestaurantId == 0)
                    return Ok(new { success = false, message = "Resturant is required!" });

                var dupCheck = _context.R_Branches.Where(x => x.Name.ToLower() == model.Name.ToLower() && x.IsActive == true && x.RestaurantId == model.RestaurantId).FirstOrDefault();
                if (dupCheck != null)
                {
                    return Ok(new { success = false, message = "This Branch is already present. Please add a different one!" });
                }
                if (model.Id == 0)
                {
                    _context.R_Branches.Add(MapperHelper.Map<R_Branch, R_BranchModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.R_Branches.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.Name = model.Name;
                        record.RestaurantId = model.RestaurantId;
                        record.Location = model.Location;
                        record.Capacity = model.Capacity;
                        record.IsActive = model.IsActive;
                    }
                    ;

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

        [HttpGet, Route("GetR_Branches")]
        public IActionResult GetR_Branches()
        {
            List<R_BranchModel> model = new List<R_BranchModel>();
            model = MapperHelper.MapList<R_BranchModel, R_Branch>(_context.R_Branches.Where(p => p.IsActive == true).ToList());

            return Ok(model);
        }

        [HttpGet, Route("GetR_BranchesByRestaurantId")]
        public IActionResult GetR_BranchesByRestaurantId(int RestaurantId)
        {
            if (RestaurantId == 0)
                return Ok(new { success = false, message = "Resturant is required!" });

            List<R_BranchModel> model = new List<R_BranchModel>();
            model = MapperHelper.MapList<R_BranchModel, R_Branch>(_context.R_Branches.Where(p => p.IsActive == true
                && p.RestaurantId == RestaurantId).ToList());

            return Ok(model);
        }

        [HttpPost("SaveR_Event")]
        public IActionResult SaveR_Event([FromBody] R_EventModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                    return Ok(new { success = false, message = "Name is required!" });

                if (model.RestaurantId == 0 && model.BranchId == 0)
                    return Ok(new { success = false, message = "Resturant and Branch are required!" });

                if (model.Id == 0)
                {
                    _context.R_Events.Add(MapperHelper.Map<R_Event, R_EventModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.R_Events.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.Name = model.Name;
                        record.RestaurantId = model.RestaurantId;
                        record.BranchId = model.BranchId;
                        record.IsActive = model.IsActive;
                    }
                    ;

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

        [HttpGet, Route("GetR_Events")]
        public IActionResult GetR_Events()
        {
            List<R_EventModel> model = new List<R_EventModel>();
            model = MapperHelper.MapList<R_EventModel, R_Event>(_context.R_Events.Where(p => p.IsActive == true).ToList());

            return Ok(model);
        }

        [HttpGet, Route("GetR_EventsByResturandandBranch")]
        public IActionResult GetR_EventsByResturandandBranch(int RestaurantId, int BranchId)
        {
            if (RestaurantId == 0 && BranchId == 0)
                return Ok(new { success = false, message = "Resturant and Branch is required!" });

            List<R_EventModel> model = new List<R_EventModel>();
            model = MapperHelper.MapList<R_EventModel, R_Event>(_context.R_Events.Where(p => p.IsActive == true
                && p.RestaurantId == RestaurantId && p.BranchId == BranchId).ToList());

            return Ok(model);
        }

        [HttpPost("SaveR_Offer")]
        public IActionResult SaveR_Offer([FromBody] R_OfferModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.OfferType) || model.RestaurantId == 0)
                {
                    return Ok("Offer Type or Resturant is required!");
                }
                var dupCheck = _context.R_Offers.Where(x => x.OfferType.ToLower() == model.OfferType.ToLower() && x.RestaurantId == model.RestaurantId && x.IsActive == model.IsActive).FirstOrDefault();
                if (dupCheck != null)
                {
                    return Ok(new { success = false, message = "This Resturant Offer is already present. Please add a different one!" });
                }
                if (model.Id == 0)
                {
                    _context.R_Offers.Add(MapperHelper.Map<R_Offer, R_OfferModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.R_Offers.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.RestaurantId = model.RestaurantId;
                        record.OfferType = model.OfferType;
                        record.StartDate = model.StartDate;
                        record.EndDate = model.EndDate;
                        record.StartTime = model.StartTime;
                        record.EndTime = model.EndTime;
                        record.IsActive = model.IsActive;
                    }
                    ;

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

        [HttpGet, Route("GetR_Offers")]
        public IActionResult GetR_Offers()
        {
            List<R_OfferModel> model = new List<R_OfferModel>();
            model = MapperHelper.MapList<R_OfferModel, R_Offer>(_context.R_Offers.Where(p => p.IsActive == true).ToList());

            return Ok(model);
        }

        [HttpGet, Route("GetR_OffersByRestaurantId")]
        public IActionResult GetR_OffersByRestaurantId(int RestaurantId)
        {
            if (RestaurantId == 0)
                return Ok(new { success = false, message = "Restaurant is required!" });

            List<R_OfferModel> model = new List<R_OfferModel>();
            model = MapperHelper.MapList<R_OfferModel, R_Offer>(_context.R_Offers
                .Where(p => p.IsActive == true && p.RestaurantId == RestaurantId).ToList());

            return Ok(model);
        }

        [HttpPost("SaveR_Slot")]
        public IActionResult SaveR_Slot([FromBody] R_SlotModel model)
        {
            try
            {
                if (model.RestaurantId == 0 || model.BranchId == 0)
                    return Ok(new { success = false, message = "Resturant and Branch are required!" });

                var dupCheck = _context.R_Slots.Where(x => x.RestaurantId == model.RestaurantId && x.BranchId == model.BranchId &&
                        x.StartTime == model.StartTime && x.EndTime == model.EndTime && x.IsActive == model.IsActive).FirstOrDefault();
                if (dupCheck != null)
                {
                    return Ok(new { success = false, message = "This Slot is already present. Please add a different one!" });
                }
                if (model.Id == 0)
                {
                    _context.R_Slots.Add(MapperHelper.Map<R_Slot, R_SlotModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.R_Slots.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.RestaurantId = model.RestaurantId;
                        record.BranchId = model.BranchId;
                        record.StartTime = model.StartTime;
                        record.EndTime = model.EndTime;
                        record.IsActive = model.IsActive;
                    }
                    ;

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

        [HttpGet, Route("GetR_Slots")]
        public IActionResult GetR_Slots()
        {
            List<R_SlotModel> model = new List<R_SlotModel>();
            model = MapperHelper.MapList<R_SlotModel, R_Slot>(_context.R_Slots.Where(p => p.IsActive == true).ToList());

            return Ok(model);
        }

        [HttpGet, Route("GetR_SlotsByRestaurantIdandBranchId")]
        public IActionResult GetR_SlotsByRestaurantIdandBranchId(int RestaurantId, int BranchId)
        {
            if (RestaurantId == 0 || BranchId == 0)
                return Ok(new { success = false, message = "Restaurant and Branch are required!" });

            List<R_SlotModel> model = new List<R_SlotModel>();
            model = MapperHelper.MapList<R_SlotModel, R_Slot>(_context.R_Slots
                .Where(p => p.IsActive == true && p.RestaurantId == RestaurantId && p.BranchId == BranchId).ToList());

            return Ok(model);
        }

        [HttpPost("ReservationRequest")]
        public IActionResult ReservationRequest([FromBody] ReservationRequestModel model)
        {
            try
            {
                if (model.ReservationType == 0 || model.ReservationDate == null || model.RestaurantId == 0 || model.Members == 0)
                    return Ok(new { success = false, message = "Invalid Data!" });

                if (model.Id == 0)
                {
                    _context.ReservationRequests.Add(MapperHelper.Map<ReservationRequest, ReservationRequestModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.ReservationRequests.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.UserId = model.UserId;
                        record.ReservationType = model.ReservationType;
                        record.ReservationDate = model.ReservationDate;
                        record.RestaurantId = model.RestaurantId;
                        record.BranchId = model.BranchId;
                        record.OfferId = model.OfferId;
                        record.BookingTypeId = model.BookingTypeId;
                        record.SlotId = model.SlotId;
                        record.Members = model.Members;
                        record.Remarks = model.Remarks;
                    }
                    ;

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

        [HttpGet, Route("GetReservations")]
        public IActionResult GetReservations()
        {
            List<ReservationRequestModel> model = new List<ReservationRequestModel>();
            model = MapperHelper.MapList<ReservationRequestModel, ReservationRequest>(_context.ReservationRequests.Where(p => p.Id != 0).ToList());

            return Ok(model);
        }

        [HttpPost("ConfirmReservation")]
        public IActionResult ConfirmReservation(int ReservationRequestId)
        {
            try
            {
                if (ReservationRequestId == 0)
                    return BadRequest("Reservation is required!");

                var reservation = _context.ReservationRequests.Where(r => r.Id == ReservationRequestId).FirstOrDefault();

                if (reservation == null)
                    return BadRequest("Reservation not found!");

                return Ok(new { success = true, message = "Reservation confirmed!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong: " + ex.Message);
            }
        }

        [HttpGet, Route("GetReviews")]
        public IActionResult GetReviews()
        {
            List<ReviewModel> model = new List<ReviewModel>();
            model = MapperHelper.MapList<ReviewModel, Review>(_context.Reviews.Where(p => p.Id != 0).ToList());

            return Ok(model);
        }

        [HttpPost("AddReview")]
        public IActionResult AddReview([FromBody] ReviewModel model)
        {
            try
            {
                _context.Reviews.Add(MapperHelper.Map<Review, ReviewModel>(model));
                _context.SaveChanges();
                return Ok(new { success = true, message = "Saved Successfully!" });
            }
            catch (Exception)
            {
                return Ok("Something went wrong!");
            }
        }

        [HttpGet, Route("GetMenuByRestaurantIdandOfferId")]
        public IActionResult GetMenuByRestaurantIdandOfferId(int RestaurantId, int OfferId)
        {
            List<R_MenuModel> model = new List<R_MenuModel>();
            model = MapperHelper.MapList<R_MenuModel, R_Menu>(_context.R_Menus.Where(p => p.RestaurantId == RestaurantId
                                            && p.OfferId == OfferId).ToList());

            return Ok(model);
        }

        [HttpPost("SaveMenu")]
        public IActionResult SaveMenu([FromBody] R_MenuModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.ItemName))
                    return Ok(new { success = false, message = "Item Name is required!" });

                if (model.RestaurantId == 0)
                    return Ok(new { success = false, message = "Resturant is required!" });

                var dupCheck = _context.R_Menus.Where(x => x.ItemName.ToLower() == model.ItemName.ToLower() && x.IsActive == true &&
                            x.OfferId == model.OfferId && x.RestaurantId == model.RestaurantId).FirstOrDefault();
                if (dupCheck != null)
                {
                    return Ok(new { success = false, message = "This Item is already present. Please add a different one!" });
                }
                if (model.Id == 0)
                {
                    _context.R_Menus.Add(MapperHelper.Map<R_Menu, R_MenuModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.R_Menus.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.RestaurantId = model.RestaurantId;
                        record.OfferId = model.OfferId;
                        record.ItemName = model.ItemName;
                        record.ItemDetail = model.ItemDetail;
                        record.Price = model.Price;
                        record.DiscountedPrice = model.DiscountedPrice;
                        record.ItemImage = model.ItemImage;
                        record.IsActive = model.IsActive;
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
