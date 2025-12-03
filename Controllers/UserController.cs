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

        [HttpGet, Route("GetSignUpRequest")]
        public IActionResult GetSignUpRequest()
        {
            List<SignUpUsersModel> model = new List<SignUpUsersModel>();
            model = MapperHelper.MapList<SignUpUsersModel, SignUpUser>(_context.SignUpUsers.Where(u => u.Status == false).ToList());

            return Ok(model);
        }

        [HttpPost, Route("ConfirmSignUp")]
        public IActionResult ConfirmSignUp(string UserCode, int userId, int userTypeId, string ConfirmedBy)
        {
            if (userId == 0 || userTypeId == 0)
                return Ok("User and User Type is required!");

            var user = _context.SignUpUsers.FirstOrDefault(u => u.Id == userId);

            var newCont = new tblAuthentication
            {
                UserCode = string.IsNullOrEmpty(UserCode) ? user.UserName : UserCode,
                UserId = userId,
                username = user.UserName,
                Password = user.Password,
                UserTypeId = userTypeId,
                isActive = true,
                CreationDate = DateTime.Now,
                CreatedBy = ConfirmedBy
            };

            _context.tblAuthentications.Add(newCont);

            user.Status = true;

            _context.SaveChanges();

            return Ok(new { success = true, message = "Signed Up successfully" });
        }
    }
}
