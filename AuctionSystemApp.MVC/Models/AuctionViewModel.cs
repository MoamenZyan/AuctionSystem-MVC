using AuctionSystemApp.Domain.Entities;

namespace AuctionSystemApp.MVC.Models
{
    public class AuctionViewModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public IFormFile AuctionPhoto { get; set; } = null!;
    }
}
