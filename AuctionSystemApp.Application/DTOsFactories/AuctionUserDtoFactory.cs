using AuctionSystemApp.Application.DTOs;
using AuctionSystemApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Application.DTOsFactories
{
    public class AuctionUserDtoFactory
    {
        public static AuctionUserDto CreateAuctionUserDto(AuctionUser auctionUser)
        {
            return new AuctionUserDto(auctionUser);
        }
    }
}
