using SendGrid.Helpers.Mail;
using SendGrid;
using AuctionSystemApp.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using AuctionSystemApp.Application.Interfaces.StrategiesInterfaces;


namespace AuctionSystemApp.Infrastructure.Services.EmailService.EmailStrategies
{
    public class WelcomeEmailStrategy : IWelcomeEmailStrategy
    {
        private readonly SendGridConfigurations _configurations;
        public WelcomeEmailStrategy(IOptions<SendGridConfigurations> configurations)
        {
            _configurations = configurations.Value;
        }
        public async Task Send(string userName, string to, Dictionary<string, string> body)
        {
            var client = new SendGridClient(_configurations.ApiKey);
            var from = new EmailAddress(_configurations.From, "AuctionSystem");
            var subject = "Welcome to Auction System!";
            var toUser = new EmailAddress(to);
            var htmlContent = $"<strong>{userName}, Welcome to Auction System!\nGo explore auctions and participate in one !</strong>";
            var msg = MailHelper.CreateSingleEmail(from, toUser, subject, "", htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
