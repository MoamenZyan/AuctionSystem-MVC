using AuctionSystemApp.Application.Interfaces.StrategiesInterfaces;
using AuctionSystemApp.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Infrastructure.Services.EmailService.EmailStrategies
{
    public class OtpEmailStrategy : IOtpEmailStrategy
    {
        private readonly SendGridConfigurations _configurations;
        public OtpEmailStrategy(IOptions<SendGridConfigurations> configurations)
        {
            _configurations = configurations.Value;
        }
        public async Task Send(string userName, string to, Dictionary<string, string> body)
        {
            var client = new SendGridClient(_configurations.ApiKey);
            var from = new EmailAddress(_configurations.From, "AuctionSystem");
            var subject = "OTP";
            var toUser = new EmailAddress(to);
            var htmlContent = $"<strong>{userName}, Your OTP: {body["OTP"]}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, toUser, subject, "", htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
