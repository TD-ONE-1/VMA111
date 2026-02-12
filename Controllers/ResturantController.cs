using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using RMS.Common.Helper;
using RMS.Entity;
using RMS.Models;
using System.Numerics;

namespace RMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        private readonly RMSContext _context;
        private readonly IWebHostEnvironment _env;
        public ResturantController(RMSContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost("SaveResturant")]
        public IActionResult SaveResturant([FromBody] ResturantModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                    return Ok(new { success = false, message = "Name is required!" });

                var dupCheck = _context.Restaurants.Where(x => x.Name.ToLower() == model.Name.ToLower() && x.IsActive == true).FirstOrDefault();
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
                        record.About_Description = model.About_Description;
                        record.CuisineType = model.CuisineType;
                        record.PriceRange = model.PriceRange;
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

        [HttpGet, Route("GetResturants")]
        public IActionResult GetResturants()
        {
            List<ResturantModel> model = new List<ResturantModel>();
            model = MapperHelper.MapList<ResturantModel, Restaurant>(_context.Restaurants.Where(p => p.IsActive == true).ToList());

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
                        record.Name = model.Name;
                        record.Address = model.Address;
                        record.PhoneNumber = model.PhoneNumber;
                        record.Email = model.Email;
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
                if (string.IsNullOrEmpty(model.Offer) || model.RestaurantId == 0)
                {
                    return Ok("Offer Type or Resturant is required!");
                }
                var dupCheck = _context.R_Offers.Where(x => x.Offer.ToLower() == model.Offer.ToLower() && x.RestaurantId == model.RestaurantId && x.IsActive == model.IsActive).FirstOrDefault();
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
                        record.Offer = model.Offer;
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
                        record.OfferId = model.OfferId;
                        record.Day = model.Day;
                        record.StartTime = model.StartTime;
                        record.EndTime = model.EndTime;
                        record.Duration = model.Duration;
                        record.Maximum_Capacity = model.Maximum_Capacity;
                        record.IsActive = model.IsActive;
                        record.BreakStartTime = model.BreakStartTime;
                        record.BreakEndTime = model.BreakEndTime;
                        record.BreakDuration = model.BreakDuration;
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

        [HttpGet, Route("GetR_Slots")]
        public IActionResult GetR_Slots()
        {
            List<R_SlotModel> model = new List<R_SlotModel>();
            model = MapperHelper.MapList<R_SlotModel, R_Slot>(_context.R_Slots.Where(p => p.IsActive == true).ToList());

            return Ok(model);
        }

        [HttpGet, Route("GetSlotsByIsEidReservation")]
        public IActionResult GetSlotsByIsEidReservation(bool isEidReservation)
        {
            List<R_SlotModel> model = new List<R_SlotModel>();
            model = MapperHelper.MapList<R_SlotModel, R_Slot>(_context.R_Slots.Where(p => p.IsActive == true && p.isEidReservation == isEidReservation).ToList());

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
                        record.PhoneNo = model.PhoneNo;
                        record.ReservationName = model.ReservationName;
                        record.IsArrived = model.IsArrived;
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

        [HttpGet, Route("GetReservationsByUserId")]
        public IActionResult GetReservationsByUserId(int UserId)
        {
            List<ReservationRequestModel> model = new List<ReservationRequestModel>();
            model = MapperHelper.MapList<ReservationRequestModel, ReservationRequest>(_context.ReservationRequests.Where(p => p.UserId == UserId).ToList());

            return Ok(model);
        }

        [HttpPost("ConfirmReservation")]
        public async Task<IActionResult> ConfirmReservation(string ReservationRequestIds, int StatusType)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ReservationRequestIds))
                    return BadRequest("Reservation is required!");

                var ids = ReservationRequestIds
                    .Split(',')
                    .Select(id => Convert.ToInt32(id.Trim()))
                    .ToList();

                var reservations = await _context.ReservationRequests.Where(r => ids.Contains(r.Id)).ToListAsync();

                if (!reservations.Any())
                    return NotFound("No reservations found.");

                if(StatusType == 3)
                {
                    foreach (var reservation in reservations)
                    {
                        reservation.IsArrived = true;
                    }
                }
                else
                {
                    foreach (var reservation in reservations)
                    {
                        reservation.Status = StatusType;
                    }
                }                    
                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "Reservations updated successfully!" });
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
            model = MapperHelper.MapList<ReviewModel, Review>(_context.Reviews.Where(p => p.Id != 0).OrderByDescending(p => p.Id).ToList());

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

        [HttpPost("SaveR_Media")]
        public IActionResult SaveR_Media([FromForm] RestaurantImageUploadModel model)
        {
            try
            {
                if (model.RestaurantId == 0)
                    return Ok(new { success = false, message = "RestaurantId is required!" });

                if (model.Logo != null)
                {
                    var old = _context.R_Images
                                      .Where(x => x.RestaurantId == model.RestaurantId && x.ImageType == "Logo")
                                      .ToList();
                    _context.R_Images.RemoveRange(old);

                    _context.R_Images.Add(new R_Image
                    {
                        RestaurantId = model.RestaurantId,
                        ImageType = "Logo",
                        Image = model.Logo,
                    });
                }

                if (model.Banner != null)
                {
                    var old = _context.R_Images
                                      .Where(x => x.RestaurantId == model.RestaurantId && x.ImageType == "Banner")
                                      .ToList();
                    _context.R_Images.RemoveRange(old);

                    _context.R_Images.Add(new R_Image
                    {
                        RestaurantId = model.RestaurantId,
                        ImageType = "Banner",
                        Image = model.Banner
                    });
                }

                if (model.Gallery != null)
                {
                    foreach (var img in model.Gallery)
                    {
                        _context.R_Images.Add(new R_Image
                        {
                            RestaurantId = model.RestaurantId,
                            ImageType = "Gallery",
                            Image = img,
                        });
                    }
                }

                _context.SaveChanges();

                return Ok(new { success = true, message = "Images saved successfully!" });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("GetR_MediaByRestaurantId")]
        public IActionResult GetR_MediaByRestaurantId(int RestaurantId)
        {
            var images = _context.R_Images
                                 .Where(x => x.RestaurantId == RestaurantId)
                                 .ToList();

            return Ok(new
            {
                success = true,
                data = new
                {
                    Logo = images.FirstOrDefault(x => x.ImageType == "Logo")?.Image,
                    Banner = images.FirstOrDefault(x => x.ImageType == "Banner")?.Image,
                    Gallery = images.Where(x => x.ImageType == "Gallery")
                                    .Select(x => x.Image)
                                    .ToList()
                }
            });
        }

        [HttpGet, Route("GetReservations/{id:int}")]
        public IActionResult GetReservations(int id)
        {
            var result = (from r in _context.ReservationRequests
                          join rest in _context.Restaurants
                              on r.RestaurantId equals rest.Id into restJoin
                          from rest in restJoin.DefaultIfEmpty()

                          join br in _context.R_Branches
                              on r.BranchId equals br.Id into brJoin
                          from br in brJoin.DefaultIfEmpty()

                          join off in _context.R_Offers
                              on r.OfferId equals off.Id into offJoin
                          from off in offJoin.DefaultIfEmpty()

                          join bt in _context.R_BookingTypes
                              on r.BookingTypeId equals bt.Id into btJoin
                          from bt in btJoin.DefaultIfEmpty()

                          join sl in _context.R_Slots
                              on r.SlotId equals sl.Id into slJoin
                          from sl in slJoin.DefaultIfEmpty()

                          where r.Id == id
                          select new ReservationWithDescriptionModel
                          {
                              Id = r.Id,
                              RestaurantId = r.RestaurantId,
                              RestaurantDescription = rest.Name,
                              BranchId = r.BranchId,
                              BranchDescription = br.Name,
                              OfferId = r.OfferId,
                              OfferDescription = off.Offer,
                              BookingTypeId = r.BookingTypeId,
                              BookingTypeDescription = bt.Name,
                              SlotId = r.SlotId,
                              SlotDescription = "",
                              BookingDate = r.ReservationDate,
                              Members = r.Members,
                              Remarks = r.Remarks,
                              Status = r.Status,
                          }).OrderByDescending(p => p.Id).FirstOrDefault();

            if (result == null)
                return NotFound($"Reservation with ID {id} not found.");

            return Ok(result);
        }

        [HttpGet, Route("GetReservationsByStatus")]
        public IActionResult GetReservationsByStatus(int status)
        {
            List<vwReservationModel> model = new List<vwReservationModel>();
            if(status >= 0)
                model = MapperHelper.MapList<vwReservationModel, vwReservation>(_context.vwReservations.Where(p => p.Status == status).OrderByDescending(p => p.id).ToList());
            else
                model = MapperHelper.MapList<vwReservationModel, vwReservation>(_context.vwReservations.OrderByDescending(p => p.id).ToList());
            return Ok(model);
        }

        [HttpPost("SaveEventQuery")]
        public IActionResult SaveEventQuery([FromBody] EventQueryModel model)
        {
            try
            {
                if (model.EventTypeId == 0 || model.ServiceTypeId == 0)
                    return Ok(new { success = false, message = "Event and Service is required!" });

                if (model.Id == 0)
                {
                    _context.EventQueries.Add(MapperHelper.Map<EventQuery, EventQueryModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.EventQueries.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.UserId = model.UserId;
                        record.ContactPersonName = model.ContactPersonName;
                        record.CellNumber = model.CellNumber;
                        record.BookingDate = model.BookingDate;
                        record.NoOfPeople = model.NoOfPeople;
                        record.EventTypeId = model.EventTypeId;
                        record.ServiceTypeId = model.ServiceTypeId;
                        record.Timing = model.Timing;
                        record.EnquiryDate = model.EnquiryDate;
                        record.Status = model.Status;
                    };

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Updated successfully!" });
                }
                return Ok(new { success = false, message = "No action found!" });
            }
            catch (Exception ex)
            {
                return Ok("Something went wrong!");
            }
        }

        [HttpGet, Route("GetEventQuery")]
        public IActionResult GetEventQuery()
        {
            List<EventQueryModel> model = new List<EventQueryModel>();
            model = MapperHelper.MapList<EventQueryModel, EventQuery>(_context.EventQueries.OrderByDescending(p => p.Id).ToList());

            return Ok(model);
        }

        [HttpPost("ConfirmEventQueries")]
        public async Task<IActionResult> ConfirmEventQueries(string EventQueriesIds, int StatusType)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(EventQueriesIds))
                    return BadRequest("Event Query is required!");

                var ids = EventQueriesIds
                    .Split(',')
                    .Select(id => Convert.ToInt32(id.Trim()))
                    .ToList();

                var queries = await _context.EventQueries.Where(r => ids.Contains(r.Id)).ToListAsync();

                if (!queries.Any())
                    return NotFound("No event query found.");

                foreach (var que in queries)
                {
                    que.Status = StatusType;
                }

                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "Event queries updated successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something went wrong: " + ex.Message);
            }
        }

        [HttpGet, Route("GetEventQueryByStatus")]
        public IActionResult GetEventQueryByStatus(int status)
        {
            List<vwEventQueryModel> model = new List<vwEventQueryModel>();
            if (status >= 0)
                model = MapperHelper.MapList<vwEventQueryModel, vwEventQuery>(_context.vwEventQueries.Where(p => p.Status == status).OrderByDescending(p => p.id).ToList());
            else
                model = MapperHelper.MapList<vwEventQueryModel, vwEventQuery>(_context.vwEventQueries.OrderByDescending(p => p.id).ToList());

            return Ok(model);
        }

        [HttpPost("CreateRestaurant")]
        public async Task<IActionResult> CreateRestaurant([FromBody] RestaurantCreateModel model)
        {
            try
            {
                if (model == null)
                    return BadRequest("Invalid payload");

                var restaurant = new Restaurant
                {
                    Name = model.Restaurant.Name,
                    About_Description = model.Restaurant.About_Description,
                    CuisineType = model.Restaurant.CuisineType,
                    PriceRange = model.Restaurant.PriceRange,
                    IsActive = model.Restaurant.IsActive
                };

                _context.Restaurants.Add(restaurant);
                await _context.SaveChangesAsync();

                foreach (var img in model.Images ?? new())
                {
                    _context.R_Images.Add(new R_Image
                    {
                        RestaurantId = restaurant.Id,
                        ImageType = img.ImageType,
                        Image = img.File,
                        CreatedOn = DateTime.Now
                    });
                }

                foreach (var br in model.Branches ?? new())
                {
                    var branch = new R_Branch
                    {
                        RestaurantId = restaurant.Id,
                        Name = br.BranchName,
                        Address = br.Address,
                        PhoneNumber = br.Phone,
                        Email = br.Email,
                        IsActive = true
                    };

                    _context.R_Branches.Add(branch);
                    await _context.SaveChangesAsync(); 

                    foreach (var bt in model.BookingTypes.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    {
                        _context.R_BookingTypes.Add(new R_BookingType
                        {
                            RestaurantId = restaurant.Id,
                            BranchId = branch.Id,
                            Name = bt.Trim(),
                            IsActive = true
                        });
                    }

                    foreach (var of in model.Offers.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    {
                        var ofr = new R_Offer
                        {
                            RestaurantId = restaurant.Id,
                            BranchId = branch.Id,
                            Offer = of.Trim(),
                            IsActive = true
                        };

                        _context.R_Offers.Add(ofr);
                        await _context.SaveChangesAsync();

                        foreach (var s in model.Slots ?? new())
                        {
                            _context.R_Slots.Add(new R_Slot
                            {
                                RestaurantId = restaurant.Id,
                                BranchId = branch.Id,
                                OfferId = ofr.Id,
                                Day = s.Day,
                                StartTime = TimeOnly.Parse(s.StartTime),
                                EndTime = TimeOnly.Parse(s.EndTime),
                                Duration = s.Duration,
                                Maximum_Capacity = s.Maximum_Capacity,
                                IsActive = s.IsActive
                            });
                        }
                    }                   
                }

                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "Restaurant saved successfully!" });
            }
            catch (Exception ex)
            {
                return Ok("Something went wrong!");
            }
           
        }
        
        [HttpPost("SaveEidReservation")]
        public IActionResult SaveEidReservation([FromBody] EidReservationModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name) || model.NoOfMembers == 0)
                    return Ok(new { success = false, message = "Invalid Data!" });

                if (model.Id == 0)
                {
                    _context.EidReservations.Add(MapperHelper.Map<EidReservation, EidReservationModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.EidReservations.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });
                    
                    if (record != null)
                    {
                        record.Name = model.Name;
                        record.Phone = model.Phone;
                        record.NoOfMembers = model.NoOfMembers;
                        record.BookingTypeId = model.BookingTypeId;
                        record.SlotId = model.SlotId;
                        record.SpecialRequest = model.SpecialRequest;
                    }
                    ;

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Updated successfully!" });
                }
                return Ok(new { success = false, message = "No action found!" });
            }
            catch (Exception ex)
            {
                return Ok("Something went wrong!");
            }
        }

        [HttpGet, Route("GetEidReservations")]
        public IActionResult GetEidReservations()
        {
            List<vwEidReservationModel> model = new List<vwEidReservationModel>();
            model = MapperHelper.MapList<vwEidReservationModel, vwEidReservation>(_context.vwEidReservations.ToList());

            return Ok(model);
        }
    }
}
