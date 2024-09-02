using AuctionSystemApp.Application.DTOs;
using AuctionSystemApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystemApp.Application.DTOsFactories
{
    public class UserDtoFactory
    {
        public static UserDto CreateUserDto(User user)
        {
            return new UserDto(user);
        }

        public static UserMinimalDto CreateUserMinimalDto(User user)
        {
            return new UserMinimalDto(user);
        }
    }
}
