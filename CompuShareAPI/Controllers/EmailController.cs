using Application.Contracts;
using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompuShareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        IEmail _mail;
        

        public EmailController(IEmail mail)
        {
            _mail = mail;
        }

        [HttpPost("confirmation/mail")]
        public async Task <ActionResult> ConfirmationMail(int studentNumber)
        {

            string toEmail = _mail.StudentEmail(studentNumber);

            var confirmationMail = new MailDTO
            {
                ToEmail = toEmail,
                Subject = "Equip 4 Success Confirmation Mail",
                Body = "We are pleased to inform you that your request has been approved.<br/> " +
                "You will be assigned a computer and you will receive an email with a serial number for the computer that you have been"
                + " assigned to, along with further instructions about where and when you receive your computer.<br/>"+
                "Kind regards,<br/>"+
                "Equip 4 Success"
            };

            await _mail.SendConfirmationMail(confirmationMail, studentNumber);

            return Ok();
        }
    }
}
