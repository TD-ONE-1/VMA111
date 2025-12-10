using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMS.Common.Helper;
using RMS.Entity;
using RMS.Models;
using RMS.Repository.Interface;
using System.IO;

namespace RMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly RMSContext _context;
        private readonly IJWTManagerRepository _jWTManager;
        public IConfiguration Configuration;
        public UserController(RMSContext context, IJWTManagerRepository jWTManagerRepository, IConfiguration configuration)
        {
            _context = context;
            _jWTManager = jWTManagerRepository;
            Configuration = configuration;
        }

        [HttpGet, Route("GetUsers")]
        public IActionResult GetUsers()
        {
            List<AccountModel> model = new List<AccountModel>();
            model = MapperHelper.MapList<AccountModel, tblAuthentication>(_context.tblAuthentications.ToList());

            return Ok(model);
        }

        [HttpGet, Route("GetUserType")]
        public IActionResult GetUserType()
        {
            List<UserTypeModel> model = new List<UserTypeModel>();
            model = MapperHelper.MapList<UserTypeModel, UserType>(_context.UserTypes.ToList());

            return Ok(model);
        }
    }
}
