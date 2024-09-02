
using SendGrid.Helpers.Mail;
using SendGrid;

namespace AuctionSystemApp.Infrastructure.Configurations
{
    public class SendGridConfigurations
    {
        public string ApiKey { get; set; } = null!;
        public string From { get; set; } = null!;
    }
}
