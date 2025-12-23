using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMS.Common.Helper;
using RMS.Entity;
using RMS.Models;

namespace RMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly RMSContext _context;
        private readonly IWebHostEnvironment _env;
        public ServiceController(RMSContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost("SaveServiceMaster")]
        public IActionResult SaveServiceMaster([FromBody] ServiceMasterModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.ServiceName))
                    return Ok(new { success = false, message = "Service Name is required!" });

                var dupCheck = _context.ServiceMasters.Where(x => x.ServiceName.ToLower() == model.ServiceName.ToLower() && x.IsActive == true).FirstOrDefault();
                if (dupCheck != null)
                {
                    return Ok(new { success = false, message = "This Service is already present. Please add a different one!" });
                }
                if (model.Id == 0)
                {
                    _context.ServiceMasters.Add(MapperHelper.Map<ServiceMaster, ServiceMasterModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.ServiceMasters.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.ServiceName = model.ServiceName;
                        record.Status = model.Status;
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

        [HttpGet, Route("GetServiceMaster")]
        public IActionResult GetServiceMaster()
        {
            List<ServiceMasterModel> model = new List<ServiceMasterModel>();
            model = MapperHelper.MapList<ServiceMasterModel, ServiceMaster>(_context.ServiceMasters.Where(p => p.IsActive == true).ToList());

            return Ok(model);
        }

        [HttpPost("SavePackage")]
        public IActionResult SavePackage([FromBody] PackageModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.PkgName))
                    return Ok(new { success = false, message = "Service Name is required!" });

                var dupCheck = _context.Packages.Where(x => x.PkgName.ToLower() == model.PkgName.ToLower() && x.IsActive == true).FirstOrDefault();
                if (dupCheck != null)
                {
                    return Ok(new { success = false, message = "This Package is already present. Please add a different one!" });
                }
                if (model.Id == 0)
                {
                    _context.Packages.Add(MapperHelper.Map<Package, PackageModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.Packages.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.PkgName = model.PkgName;
                        record.MinCapacity = model.MinCapacity;
                        record.MaxCapacity = model.MaxCapacity;
                        record.Price = model.Price;
                        record.PkgServiceId = model.PkgServiceId;
                        record.Status = model.Status;
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

        [HttpGet, Route("GetPackages")]
        public IActionResult GetPackages()
        {
            List<PackageModel> model = new List<PackageModel>();
            model = MapperHelper.MapList<PackageModel, Package>(_context.Packages.Where(p => p.IsActive == true).ToList());

            return Ok(model);
        }

        [HttpPost("SavePackageService")]
        public IActionResult SavePackageService([FromBody] PackageServiceModel model)
        {
            try
            {
                if (model.PackageId == 0 || model.ServiceId == 0)
                    return Ok(new { success = false, message = "Package and Service is required!" });

                var dupCheck = _context.PackageServices.Where(x => x.PackageId == model.PackageId &&
                                            x.ServiceId == model.ServiceId && x.IsActive == true).FirstOrDefault();
                if (dupCheck != null)
                {
                    return Ok(new { success = false, message = "This Package Service already present. Please tagged a different one!" });
                }
                if (model.Id == 0)
                {
                    _context.PackageServices.Add(MapperHelper.Map<PackageService, PackageServiceModel>(model));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Saved Successfully!" });
                }
                if (model.Id != 0)
                {
                    var record = _context.PackageServices.FirstOrDefault(p => p.Id == model.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record != null)
                    {
                        record.PackageId = model.PackageId;
                        record.ServiceId = model.ServiceId;
                        record.Status = model.Status;
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

        [HttpGet, Route("GetPackageService")]
        public IActionResult GetPackageService()
        {
            List<PackageServiceModel> model = new List<PackageServiceModel>();
            model = MapperHelper.MapList<PackageServiceModel, PackageService>(_context.PackageServices.Where(p => p.IsActive == true).ToList());

            return Ok(model);
        }
    }
}
