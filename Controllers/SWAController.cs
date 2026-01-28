using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RMS.Common.Helper;
using RMS.Entity;
using RMS.Models;
using RMS.Models.SecondApp;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace RMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SWAController : ControllerBase
    {
        private readonly RMSContext _context;
        private readonly IWebHostEnvironment _env;
        public SWAController(RMSContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost("SaveProducts")]
        public IActionResult SaveProducts([FromBody] ProductsModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                    return Ok(new { success = false, message = "Name is required!" });

                if (model.ProductId == 0)
                {
                    _context.Products.Add(MapperHelper.Map<Product, ProductsModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.ProductId != 0)
                {
                    var record = _context.Products.FirstOrDefault(p => p.ProductId == model.ProductId);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.Name = model.Name;
                        record.BranchId = model.BranchId;
                        record.ProductCode = model.ProductCode;
                        record.Name = model.Name;
                        record.Price = model.Price;
                        record.CategoryTypeId = model.CategoryTypeId;
                        record.Stock = model.Stock;
                        record.Description = model.Description;
                        record.Image = model.Image;
                        record.Status = model.Status;
                        record.TDDiscount = model.TDDiscount;
                        record.TaxAppilcable = model.TaxAppilcable;
                        record.TaxPercentage = model.TaxPercentage;
                        record.CreatedOn = model.CreatedOn;
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

        [HttpPost("SaveShopkeeper")]
        public IActionResult SaveShopkeeper([FromBody] ShopkeeperModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.ShopkeeperName))
                    return Ok(new { success = false, message = "Shopkeeper Name is required!" });

                if (model.ShopkeeperId == 0)
                {
                    _context.Shopkeepers.Add(MapperHelper.Map<Shopkeeper, ShopkeeperModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.ShopkeeperId != 0)
                {
                    var record = _context.Shopkeepers.FirstOrDefault(p => p.ShopkeeperId == model.ShopkeeperId);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {           
                        record.ShopkeeperName = model.ShopkeeperName;
                        record.BusinessName = model.BusinessName;
                        record.BusinessTypeId = model.BusinessTypeId;
                        record.Address = model.Address;
                        record.NTN = model.NTN;
                        record.CNIC = model.CNIC;
                        record.PhoneNo = model.PhoneNo;
                        record.MobileNumber = model.MobileNumber;
                        record.Website = model.Website;
                        record.Email = model.Email;
                        record.Status = model.Status;
                        record.Latitude = model.Latitude;
                        record.Longitude = model.Longitude;
                        record.RatingId = model.RatingId;
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

        [HttpGet, Route("GetShopkeeperByBussinessTypeId")]
        public IActionResult GetShopkeeperByBussinessTypeId(int BussinessTypeId)
        {
            if (BussinessTypeId == 0)
                return Ok(new { success = false, message = "Bussiness Type is required!" });

            List<ShopkeeperModel> model = new List<ShopkeeperModel>();
            model = MapperHelper.MapList<ShopkeeperModel, Shopkeeper>(_context.Shopkeepers.Where(p => p.Status == true
                && p.BusinessTypeId == BussinessTypeId).ToList());

            return Ok(model);
        }

        [HttpPost("SaveCustomer")]
        public IActionResult SaveCustomer([FromBody] CustomerModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.CustName))
                    return Ok(new { success = false, message = "Customer Name is required!" });

                if (model.CustomerId == 0)
                {
                    _context.Customers.Add(MapperHelper.Map<Customer, CustomerModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.CustomerId != 0)
                {
                    var record = _context.Customers.FirstOrDefault(p => p.CustomerId == model.CustomerId);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.CustomerCode = model.CustomerCode;
                        record.CustName = model.CustName;
                        record.CustAccountCode = model.CustAccountCode;
                        record.Address = model.Address;
                        record.NTN = model.NTN;
                        record.CNIC = model.CNIC;
                        record.PhoneNo = model.PhoneNo;
                        record.MobileNo = model.MobileNo;
                        record.Email = model.Email;
                        record.Status = model.Status;
                        record.Latitude = model.Latitude;
                        record.Longitude = model.Longitude;
                        record.RatingId = model.RatingId;
                        record.PaymentTermId = model.PaymentTermId;
                        record.Discount = model.Discount;
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
    }
}
