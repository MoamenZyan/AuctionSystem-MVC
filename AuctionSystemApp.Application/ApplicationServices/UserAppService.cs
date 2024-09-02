using AuctionSystemApp.Application.DTOs;
using AuctionSystemApp.Application.DTOsFactories;
using AuctionSystemApp.Application.Interfaces;
using AuctionSystemApp.Application.Interfaces.StrategiesInterfaces;
using AuctionSystemApp.Domain.Entities;
using AuctionSystemApp.Domain.Factories;
using AuctionSystemApp.Domain.Interfaces.ServicesInterfaces;
using AuctionSystemApp.Domain.Services;
using AuctionSystemApp.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AuctionSystemApp.Application.ApplicationServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        private readonly IFileSystem _fileSystem;
        private readonly IWelcomeEmailStrategy _welcomeEmailStrategy;
        private readonly IOtpEmailStrategy _otpEmailStrategy;
        private readonly INotificationContext _notificationContext;
        private readonly IOtpService _otpService;
        private readonly IUserVerifiedEmailStrategy _userVerifiedEmailStrategy;
        private readonly IJwtService _jwtService;
        private readonly IAuctionService _auctionService;
        public UserAppService(IUserService userService,
                              IFileSystem fileSystem,
                              INotificationContext notificationContext,
                              IWelcomeEmailStrategy welcomeEmailStrategy,
                              IOtpService otpService,
                              IOtpEmailStrategy otpEmailStrategy,
                              IUserVerifiedEmailStrategy userVerifiedEmailStrategy,
                              IJwtService jwtService,
                              IAuctionService auctionService)
        {
            _userService = userService;
            _fileSystem = fileSystem;
            _notificationContext = notificationContext;
            _welcomeEmailStrategy = welcomeEmailStrategy;
            _otpService = otpService;
            _otpEmailStrategy = otpEmailStrategy;
            _userVerifiedEmailStrategy = userVerifiedEmailStrategy;
            _jwtService = jwtService;
            _auctionService = auctionService;
        }

        public async Task<UserDto?> CreateNewUser(Dictionary<string, string> userInfo, IFormFile photo)
        {
            Guid guid = Guid.NewGuid();
            var photoResult = await _fileSystem.AddPhoto(guid, "user", photo);
            if (photoResult == null)
                return null;

            userInfo.Add("PhotoPath", photoResult);
            var result = await _userService.CreateUser(userInfo);
            if (result == null)
                return null;

            _notificationContext.SetNotificationStrategy(_welcomeEmailStrategy);
            await _notificationContext.Send(result.Fname, result.Email, new Dictionary<string, string>());

            return UserDtoFactory.CreateUserDto(result);
        }

        public async Task<UserDto?> GetCurrentUserInfo(int userId)
        {
            User? user = await _userService.GetUserByHisId(userId);
            if (user == null)
                return null;

            return UserDtoFactory.CreateUserDto(user);
        }

        public List<AuctionDto>? GetUserAuctions(int userId)
        {
            var auctions = _auctionService.GetAllUserAuctions(userId);
            return auctions?.Select(x => AuctionDtoFactory.CreateAuctionDto(x)).ToList();
        }

        public async Task<bool> SendUserOTP(string email)
        {
            _notificationContext.SetNotificationStrategy(_otpEmailStrategy);
            Dictionary<string, string> body = new Dictionary<string, string>();

            var user = _userService.GetUserByHisEmail(email);
            if (user == null) return false;

            var userOTP = await _otpService.GetOtpByUserId(user.Id);
            if (userOTP != null)
            {
                userOTP.OTP = OtpService.Generate();
                userOTP.Deadline = DateTime.UtcNow.AddMinutes(10);
                await _otpService.UpdateUserOTP(userOTP);

                body.Add("OTP", userOTP.OTP);
                await _notificationContext.Send(user.Fname, user.Email, body);
            }
            else
            {
                userOTP = await _otpService.CreateUserOTP(user.Id);

                body.Add("OTP", userOTP.OTP);
                await _notificationContext.Send(user.Fname, user.Email, body);
            }
            return true;
        }

        public async Task<string?> VerifyUserOTP(string email, string otp)
        {
            if (string.IsNullOrEmpty(otp) || string.IsNullOrEmpty(email))
                return null;

            User? user = _userService.GetUserByHisEmail(email);
            if(user == null) return null;

            var result = await _otpService.VerfiyOTP(otp, user.Id);
            if (!result)
                return null;

            _notificationContext.SetNotificationStrategy(_userVerifiedEmailStrategy);
            await _notificationContext.Send(user.Fname, user.Email, null!);
            var token = _jwtService.GenerateJwtToken(user.Id);
            return token;
        }
    }
}
