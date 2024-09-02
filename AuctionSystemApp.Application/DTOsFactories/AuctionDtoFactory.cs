using AuctionSystemApp.Application.DTOs;
using AuctionSystemApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Application.DTOsFactories
{
    public class AuctionDtoFactory
    {
        public static AuctionDto CreateAuctionDto(Auction auction)
        {
            return new AuctionDto(auction);
        }

        public static AuctionMinimalDto CreateAuctionMinimalDto(Auction auction)
        {
            return new AuctionMinimalDto(auction);
        }
    }
}
