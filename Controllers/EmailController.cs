using EmailApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System;
using static EmailApi.Interfaces.Interfaces;

namespace EmailApi.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public async Task<ActionResult> send_mail(EmailIO res)
        {
            try
            {
                var mail = new MailMessage();
                var client = new SmtpClient(_emailService.get_mailserv(), 2525)
                {
                    Credentials = new NetworkCredential(_emailService.get_username(), _emailService.get_password()),
                    EnableSsl = true
                };
                mail.From = new MailAddress(_emailService.get_mailaddress());
                mail.To.Add(res.Email);
                mail.Subject = res.Subject;
                var htmlView = AlternateView.CreateAlternateViewFromString(res.Body, null, "text/html");
                mail.AlternateViews.Add(htmlView);
                client.Send(mail);
                return Ok();


            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
