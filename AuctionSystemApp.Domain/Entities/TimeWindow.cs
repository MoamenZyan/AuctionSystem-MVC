using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Domain.Entities
{
    public class TimeWindow
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public TimeWindow(DateTime From, DateTime To)
        {
            this.From = From;
            this.To = To;
        }
    }
}
