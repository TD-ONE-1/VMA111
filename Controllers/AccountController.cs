﻿using Microsoft.AspNetCore.Mvc;
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

                if (login.username == null || login.Password == null)
                {
                    return Ok("Invalid UserName or Password!");
                }
                var user = _context.tblAuthentications.Where(x => x.isActive == true && (x.username == login.username || x.UserCode == login.username) && x.Password == login.Password).FirstOrDefault();
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

            return Unauthorized();
        }

        [HttpPost("UsersSignUp")]
        public IActionResult UsersSignUp([FromBody] SignUpUsersModel user)
        {
            try
            {
                if (user.UserName == null || user.Password == null)
                {
                    return Ok("UserName or Password is required!");
                }
                if (user.Id == 0)
                {
                    var dupCheck = _context.SignUpUsers.Where(x => x.UserName == user.UserName).FirstOrDefault();
                    if (dupCheck != null)
                    {
                        return Ok(new { success = false, message = "This User Name is already present. Please add a different one!" });
                    }

                    _context.SignUpUsers.Add(MapperHelper.Map<SignUpUser, SignUpUsersModel>(user));

                    _context.SaveChanges();

                    return Ok(new { success = true, message = "Successful Sign Up!" });
                }
                if (user.Id != 0)
                {
                    var record = _context.SignUpUsers.FirstOrDefault(p => p.Id == user.Id);

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
                        record.Date = user.Date ?? user.Date;
                        record.Status = user.Status;
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
