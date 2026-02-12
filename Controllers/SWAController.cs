using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        [HttpPost("SaveProduct")]
        public IActionResult SaveProduct([FromBody] ProductsModel model)
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

        [HttpGet, Route("GetProducts")]
        public IActionResult GetProducts()
        {
            List<ProductsModel> model = new List<ProductsModel>();
            model = MapperHelper.MapList<ProductsModel, Product>(_context.Products.Where(p => p.Status == true).ToList());

            return Ok(model);
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

        [HttpGet, Route("GetShopkeepers")]
        public IActionResult GetShopkeepers()
        {
            List<ShopkeeperModel> model = new List<ShopkeeperModel>();
            model = MapperHelper.MapList<ShopkeeperModel, Shopkeeper>(_context.Shopkeepers.Where(p => p.Status == true).ToList());

            return Ok(model);
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

        [HttpGet, Route("GetCustomers")]
        public IActionResult GetCustomers()
        {
            List<CustomerModel> model = new List<CustomerModel>();
            model = MapperHelper.MapList<CustomerModel, Customer>(_context.Customers.Where(p => p.Status == true).ToList());

            return Ok(model);
        }

        [HttpPost("SaveShopBranch")]
        public IActionResult SaveShopBranch([FromBody] ShopBranchModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.BranchName))
                    return Ok(new { success = false, message = "Branch Name is required!" });

                if (model.BranchID == 0)
                {
                    _context.ShopBranches.Add(MapperHelper.Map<ShopBranch, ShopBranchModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.BranchID != 0)
                {
                    var record = _context.ShopBranches.FirstOrDefault(p => p.BranchID == model.BranchID);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.ShopkeeperId = model.ShopkeeperId;
                        record.BranchName = model.BranchName;
                        record.PhoneNo = model.PhoneNo;
                        record.MobileNumber = model.MobileNumber;
                        record.Email = model.Email;
                        record.Address = model.Address;       
                        record.Latitude = model.Latitude;
                        record.Longitude = model.Longitude;
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

        [HttpGet, Route("GetShopBranches")]
        public IActionResult GetShopBranches()
        {
            List<ShopBranchModel> model = new List<ShopBranchModel>();
            model = MapperHelper.MapList<ShopBranchModel, ShopBranch>(_context.ShopBranches.Where(p => p.Status == true).ToList());

            return Ok(model);
        }

        [HttpPost("SaveOrder")]
        public IActionResult SaveOrder([FromBody] OrdersModel model)
        {
            try
            {
                if (model.Quantity == 0 || model.ShopkeeperId == 0 || model.BranchId == 0 || model.CustomerId == 0 || model.ProductId == 0)
                    return Ok(new { success = false, message = "Invalid Data!" });

                if (model.OrderId == 0)
                {
                    _context.Orders.Add(MapperHelper.Map<Order, OrdersModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.OrderId != 0)
                {
                    var record = _context.Orders.FirstOrDefault(p => p.OrderId == model.OrderId);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.ShopkeeperId = model.ShopkeeperId;
                        record.BranchId = model.BranchId;
                        record.CustomerId = model.CustomerId;
                        record.ProductId = model.ProductId;
                        record.Quantity = model.Quantity;
                        record.Price = model.Price;
                        record.Discount = model.Discount;
                        record.Cost = model.Cost;
                        record.TaxApplicable = model.TaxApplicable;
                        record.TaxPercentage = model.TaxPercentage;
                        record.IsDeliveryAddressChange = model.IsDeliveryAddressChange;
                        record.DeliveryAddress = model.DeliveryAddress;
                        record.ContactPerson = model.ContactPerson;
                        record.DeliveryReceivedBy = model.DeliveryReceivedBy;
                        record.Latitude = model.Latitude;
                        record.Longitude = model.Longitude;
                        record.OrderStatus = model.OrderStatus;
                        record.OrderDate = model.OrderDate;
                        record.ExpectedDeliveryDate = model.ExpectedDeliveryDate;
                        record.ConfirmDeliveryDate = model.ConfirmDeliveryDate;
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

        [HttpGet, Route("GetOrders")]
        public IActionResult GetOrders()
        {
            List<OrdersModel> model = new List<OrdersModel>();
            model = MapperHelper.MapList<OrdersModel, Order>(_context.Orders.ToList());

            return Ok(model);
        }

        [HttpPost("SavePurchaseProduct")]
        public IActionResult SavePurchaseProduct([FromBody] ProductPurchaseModel model)
        {
            try
            {
                if (model.Quantity == 0 || model.ShopkeeperId == 0 || model.BranchId == 0 || model.ProductId == 0)
                    return Ok(new { success = false, message = "Invalid Data!" });

                if (model.ProductPurchaseId == 0)
                {
                    _context.ProductPurchases.Add(MapperHelper.Map<ProductPurchase, ProductPurchaseModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.ProductPurchaseId != 0)
                {
                    var record = _context.ProductPurchases.FirstOrDefault(p => p.ProductPurchaseId == model.ProductPurchaseId);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.ShopkeeperId = model.ShopkeeperId;
                        record.BranchId = model.BranchId;
                        record.ProductId = model.ProductId;
                        record.Quantity = model.Quantity;
                        record.Price = model.Price;
                        record.PODate = model.PODate;
                        record.PONumber = model.PONumber;
                        record.TransactionType = model.TransactionType;
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

        [HttpGet, Route("GetPurchaseProducts")]
        public IActionResult GetPurchaseProducts()
        {
            List<ProductPurchaseModel> model = new List<ProductPurchaseModel>();
            model = MapperHelper.MapList<ProductPurchaseModel, ProductPurchase>(_context.ProductPurchases.ToList());

            return Ok(model);
        }

        [HttpPost("SaveProductCategory")]
        public IActionResult SaveProductCategory([FromBody] ProductCategoryModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.CategoryType))
                    return Ok(new { success = false, message = "Invalid Data!" });

                if (model.Id == 0)
                {
                    _context.ProductCategories.Add(MapperHelper.Map<ProductCategory, ProductCategoryModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.ProductCategories.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.CategoryType = model.CategoryType;
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

        [HttpGet, Route("GetProductCategories")]
        public IActionResult GetProductCategories()
        {
            List<ProductCategoryModel> model = new List<ProductCategoryModel>();
            model = MapperHelper.MapList<ProductCategoryModel, ProductCategory>(_context.ProductCategories.ToList());

            return Ok(model);
        }
    }
}
