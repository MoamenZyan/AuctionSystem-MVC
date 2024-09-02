using AuctionSystemApp.Application.DTOsFactories;
using AuctionSystemApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string PhotoPath { get; set; } = null!;

        public List<AuctionMinimalDto> OwnedAuctions { get; set; } = new List<AuctionMinimalDto>();
        public List<AuctionMinimalDto> JoinedAuctions { get; set; } = new List<AuctionMinimalDto>();

        public UserDto(User user)
        {
            Id = user.Id;
            Fname = user.Fname;
            Lname = user.Lname;
            Email = user.Email;
            Phone = user.Phone;
            PhotoPath = user.PhotoPath;

            OwnedAuctions = user.OwnedAuctions.Select(x => AuctionDtoFactory.CreateAuctionMinimalDto(x)).ToList();
            JoinedAuctions = user.JoinedAuctions.Select(x => AuctionDtoFactory.CreateAuctionMinimalDto(x.Auction)).ToList();
        }
    }

    public class UserMinimalDto
    {
        public int Id { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public UserMinimalDto(User user)
        {
            Id = user.Id;
            Fname = user.Fname;
            Lname = user.Lname;
            Email = user.Email;
            Phone = user.Phone;
        }
    }

}
