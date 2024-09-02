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
    public class UserAddedCommentOnAuctionEmailStrategy : IUserAddedCommentOnAuctionEmailStrategy
    {
        private readonly SendGridConfigurations _configurations;
        public UserAddedCommentOnAuctionEmailStrategy(IOptions<SendGridConfigurations> configurations)
        {
            _configurations = configurations.Value;
        }
        public async Task Send(string userName, string to, Dictionary<string, string> body)
        {
            var client = new SendGridClient(_configurations.ApiKey);
            var from = new EmailAddress(_configurations.From, "AuctionSystem");
            var subject = $"User added comment on your auction!";
            var toUser = new EmailAddress(to);
            var htmlContent = $"<strong>{userName}, {body["JoinedUser"]} has added comment on your auction!</strong>";
            var msg = MailHelper.CreateSingleEmail(from, toUser, subject, "", htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
