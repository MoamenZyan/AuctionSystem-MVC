using AuctionSystemApp.Application.DTOsFactories;
using AuctionSystemApp.Domain.Entities;
using AuctionSystemApp.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Application.DTOs
{
    public class AuctionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime From {  get; set; }
        public DateTime To { get; set; }
        public string PhotoPath { get; set; }



        public UserDto User { get; set; } = null!;
        public List<AuctionUserDto> JoinedUsers { get; set; } = new List<AuctionUserDto>();
        public AuctionDto(Auction auction)
        {
            Id = auction.Id;
            Name = auction.Name;
            Description = auction.Description;
            From = auction.AuctionTime.From;
            To = auction.AuctionTime.To;
            PhotoPath = auction.PhotoPath;

            User = UserDtoFactory.CreateUserDto(auction.User);
            JoinedUsers = auction.JoinedUsers.Select(x => AuctionUserDtoFactory.CreateAuctionUserDto(x)).ToList();
        }
    }

    public class AuctionMinimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public AuctionMinimalDto(Auction auction)
        {
            Id = auction.Id;
            Name = auction.Name;
            Description = auction.Description;
            From = auction.AuctionTime.From;
            To = auction.AuctionTime.To;
        }
    }
}
