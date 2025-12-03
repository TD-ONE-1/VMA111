using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMS.Entity;
using RMS.Models;
using System.Net;
using System.Net.Mail;

namespace RMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly RMSContext _context;
        public EmailController(RMSContext context)
        {
            _context = context;
        }

        [HttpPost("SendEmail")]
        public IActionResult SendEmail([FromBody] EmailRequestModel model)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential("saim281288@gmail.com", "iikpvhcmicxijuzo");
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("saim281288@gmail.com");
                mail.To.Add(model.ToEmail);
                mail.Subject = model.Subject;
                mail.Body = model.Body;

                smtpClient.Send(mail);

                return Ok(new { success = true, message = "Email Send Successfully!" });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = "Something went wrong!" });
            }       
        }
    }
}
