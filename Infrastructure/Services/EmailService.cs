using Application.Contracts;
using Application.DTOs;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MimeKit;
using MailKit.Security;
using MailKit.Net.Smtp;

using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Infrastructure.Services
{
    public class EmailService : IEmail
    {
        private readonly EmailSettings _settings;
        private readonly AppDbContext appDbContext;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> settings, AppDbContext appDbContext, ILogger<EmailService> logger)
        {
            _settings = settings.Value;
            this.appDbContext = appDbContext;
            _logger = logger;

        }

        public async Task SendConfirmationMail(MailDTO mailDto,int studentNumber)
        {
            try
            {
                var sEmail = await appDbContext.Students.FirstOrDefaultAsync(s => s.StudentNumber == studentNumber);

                if (sEmail == null)
                {
                    _logger.LogWarning($"Student not found.");
                    return;
                }
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_settings.Email));
                email.To.Add(MailboxAddress.Parse(mailDto.ToEmail));
                email.Subject = mailDto.Subject;

                var builder = new BodyBuilder();
                email.Subject = mailDto.Subject;
                builder.HtmlBody = mailDto.Body;

                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_settings.Email, _settings.Password);

                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

            }
            catch
            {

            }
        }

        public string? StudentEmail(int studentNumber)
        {
            return appDbContext.Students
         .Where(s => s.StudentNumber == studentNumber)
         .Select(s => s.Email)
         .FirstOrDefault();
        }
    }
}
