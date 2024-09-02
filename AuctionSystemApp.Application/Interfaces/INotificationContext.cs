using AuctionSystemApp.Application.Interfaces.StrategiesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Application.Interfaces
{
    public interface INotificationContext
    {
        void SetNotificationStrategy(INotificationStrategy notificationStrategy);
        Task Send(string userName, string to, Dictionary<string, string> body);
    }
}
