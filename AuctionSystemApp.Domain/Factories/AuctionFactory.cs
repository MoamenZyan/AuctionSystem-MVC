using AuctionSystemApp.Domain.Entities;
using Ganss.Xss;

namespace AuctionSystemApp.Domain.Factories
{
    public class AuctionFactory
    {
        static HtmlSanitizer sanitizer = new HtmlSanitizer();
        public static Auction CreateAuction(Dictionary<string, string> auctionInfo)
        {
            if (Convert.ToDateTime(auctionInfo["From"]) >= Convert.ToDateTime(auctionInfo["To"]))
                throw new Exception("Auction Window Time Is Incorrect");
            
            Auction auction = new Auction()
            {
                Name = sanitizer.Sanitize(auctionInfo["Name"]),
                Description = sanitizer.Sanitize(auctionInfo["Description"]),
                AuctionTime = new TimeWindow(Convert.ToDateTime(auctionInfo["From"]), Convert.ToDateTime(auctionInfo["To"])),
                UserId = Convert.ToInt32(auctionInfo["UserId"]),
                PhotoPath = auctionInfo["PhotoPath"]
            };

            return auction;
        }
    }
}
