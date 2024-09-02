using AuctionSystemApp.Application.Interfaces;
using AuctionSystemApp.Application.Interfaces.StrategiesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Infrastructure.Services.EmailService
{
    public class NotificationContext : INotificationContext
    {
        private INotificationStrategy _notificationStrategy = null!;
        public void SetNotificationStrategy(INotificationStrategy notificationStrategy)
        {
            _notificationStrategy = notificationStrategy;
        }

        public async Task Send(string userName, string to, Dictionary<string, string> body)
        {
            await _notificationStrategy.Send(userName, to, body);
        }
    }
}
