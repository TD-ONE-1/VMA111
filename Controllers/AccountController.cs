using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RMS.Common.Helper;
using RMS.Entity;
using RMS.Models;
using RMS.Repository.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly RMSContext _context;
        private readonly IJWTManagerRepository _jWTManager;
        public IConfiguration Configuration;
        public AccountController(RMSContext context, IJWTManagerRepository jWTManagerRepository, IConfiguration configuration)
        {
            _context = context;
            _jWTManager = jWTManagerRepository;
            Configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AccountModel login)
        {
            try
            {
                TokenModel model = new TokenModel();

                if (login.UserName == null || login.Password == null)
                {
                    return Ok("Invalid UserName or Password!");
                }
                var user = _context.tblAuthentications.Where(x => x.isActive == true && x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();
                if (user == null)
                {
                    return Ok("Invalid UserName or Password!");
                }
                var usr = (MapperHelper.Map<AccountModel, tblAuthentication>(user));

                model = _jWTManager.Authenticate(usr, Convert.ToInt32(Configuration["TokenTimeOutHours"]));
                model.userDetail = usr;
                return Ok(model);
            }
            catch (Exception)
            {
                return Ok("Invalid UserName or Password!");
            }
        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword([FromBody] ChangePasswordModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.UserName) ||
                    string.IsNullOrEmpty(model.OldPassword) ||
                    string.IsNullOrEmpty(model.NewPassword))
                {
                    return Ok("Invalid request!");
                }

                var user = _context.tblAuthentications
                    .FirstOrDefault(x => x.UserName == model.UserName && x.isActive);

                if (user == null)
                    return Ok("User not found!");

                if (user.Password != model.OldPassword)
                    return Ok("Old password is incorrect!");

                user.Password = model.NewPassword;
                _context.SaveChanges();

                return Ok("Password changed successfully!");
            }
            catch (Exception)
            {
                return Ok("Error while changing password!");
            }
        }

        [HttpPost("ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.UserName))
                {
                    return Ok("Invalid request!");
                }

                var user = _context.tblAuthentications
                    .FirstOrDefault(x => x.UserName == model.UserName && x.isActive);

                if (user == null)
                    return Ok("User not found!");

                var newPassword = GenerateRandomPassword();

                user.Password = newPassword;
                _context.SaveChanges();

                return Ok(new
                {
                    Message = "Password reset successfully!",
                    TempPassword = newPassword
                });
            }
            catch (Exception)
            {
                return Ok("Error while resetting password!");
            }
        }

        [HttpPost("loginJV")]
        public IActionResult loginJV([FromBody] AccountJVModel login)
        {
            try
            {
                TokenJVModel model = new TokenJVModel();

                if (login.UserName == null || login.Password == null)
                {
                    return Ok("Invalid UserName or Password!");
                }
                var user = _context.tblAuthenticationJovees.Where(x => x.isActive == true && x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();
                if (user == null)
                {
                    return Ok("Invalid UserName or Password!");
                }
                var usr = (MapperHelper.Map<AccountJVModel, tblAuthenticationJovee>(user));

                model = _jWTManager.AuthenticateJV(usr, Convert.ToInt32(Configuration["TokenTimeOutHours"]));
                model.userDetail = usr;
                return Ok(model);
            }
            catch (Exception)
            {
                return Ok("Invalid UserName or Password!");
            }
        }

        [HttpPost("ChangePasswordJV")]
        public IActionResult ChangePasswordJV([FromBody] ChangePasswordModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.UserName) ||
                    string.IsNullOrEmpty(model.OldPassword) ||
                    string.IsNullOrEmpty(model.NewPassword))
                {
                    return Ok("Invalid request!");
                }

                var user = _context.tblAuthenticationJovees
                    .FirstOrDefault(x => x.UserName == model.UserName && x.isActive);

                if (user == null)
                    return Ok("User not found!");

                if (user.Password != model.OldPassword)
                    return Ok("Old password is incorrect!");

                user.Password = model.NewPassword;
                _context.SaveChanges();

                return Ok("Password changed successfully!");
            }
            catch (Exception)
            {
                return Ok("Error while changing password!");
            }
        }        

        [HttpPost("ResetPasswordJV")]
        public IActionResult ResetPasswordJV([FromBody] ResetPasswordModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.UserName))
                {
                    return Ok("Invalid request!");
                }

                var user = _context.tblAuthenticationJovees
                    .FirstOrDefault(x => x.UserName == model.UserName && x.isActive);

                if (user == null)
                    return Ok("User not found!");

                var newPassword = GenerateRandomPassword();

                user.Password = newPassword;
                _context.SaveChanges();

                return Ok(new
                {
                    Message = "Password reset successfully!",
                    TempPassword = newPassword
                });
            }
            catch (Exception)
            {
                return Ok("Error while resetting password!");
            }
        }

        private string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        [HttpPost("UsersSignUp")]
        public IActionResult UsersSignUp([FromBody] AccountModel user)
        {
            try
            {
                if (user.UserName == null || user.Password == null)
                {
                    return Ok("UserName or Password is required!");
                }
                if (user.Id == 0)
                {
                    var dupCheck = _context.tblAuthentications.Where(x => x.UserName == user.UserName).FirstOrDefault();
                    if (dupCheck != null)
                    {
                        return Ok(new { success = false, message = "This User Name is already present. Please add a different one!" });
                    }

                    _context.tblAuthentications.Add(MapperHelper.Map<tblAuthentication, AccountModel>(user));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Successful Sign Up!" });
                }
                if (user.Id != 0)
                {
                    var record = _context.tblAuthentications.FirstOrDefault(p => p.Id == user.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record.UserName == user.UserName)
                    {
                        return Ok(new { success = false, message = "This User Name is already present. Please add a different one!" });
                    }

                    if (record != null)
                    {
                        record.UserName = user.UserName;
                        record.Password = user.Password;
                        record.UserTypeId = user.UserTypeId;
                        record.CreatedBy = user.CreatedBy;
                        record.CreationDate = user.CreationDate;
                        record.isActive = user.isActive;
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

        [HttpPost("UsersJVSignUp")]
        public IActionResult UsersJVSignUp([FromBody] AccountJVModel user)
        {
            try
            {
                if (user.UserName == null || user.Password == null)
                {
                    return Ok("UserName or Password is required!");
                }
                if (user.Id == 0)
                {
                    var dupCheck = _context.tblAuthenticationJovees.Where(x => x.UserName == user.UserName).FirstOrDefault();
                    if (dupCheck != null)
                    {
                        return Ok(new { success = false, message = "This User Name is already present. Please add a different one!" });
                    }

                    _context.tblAuthenticationJovees.Add(MapperHelper.Map<tblAuthenticationJovee, AccountJVModel>(user));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Successful Sign Up!" });
                }
                if (user.Id != 0)
                {
                    var record = _context.tblAuthenticationJovees.FirstOrDefault(p => p.Id == user.Id);

                    if (record == null)
                        return Ok(new { success = true, message = "Not Found!" });

                    if (record.UserName == user.UserName)
                    {
                        return Ok(new { success = false, message = "This User Name is already present. Please add a different one!" });
                    }

                    if (record != null)
                    {
                        record.UserName = user.UserName;
                        record.Password = user.Password;
                        record.UserTypeId = user.UserTypeId;
                        record.BusinessId = user.BusinessId;
                        record.CreationDate = user.CreationDate;
                        record.CreatedBy = user.CreatedBy;
                        record.isActive = user.isActive;
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
