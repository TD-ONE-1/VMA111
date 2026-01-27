using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMS.Common.Helper;
using RMS.Entity;
using RMS.Models;
using RMS.Models.SecondApp;

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
                        record.Price = model.Price;
                        record.CategoryType = model.CategoryType;
                        record.Stock = model.Stock;
                        record.Description = model.Description;
                        record.Image = model.Image;
                        record.Status = model.Status;
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
    }
}
