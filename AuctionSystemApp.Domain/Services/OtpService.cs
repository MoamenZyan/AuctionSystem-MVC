using AuctionSystemApp.Domain.Entities;
using AuctionSystemApp.Domain.Factories;
using AuctionSystemApp.Domain.Interfaces.RepositoriesInterfaces;
using AuctionSystemApp.Domain.Interfaces.ServicesInterfaces;

namespace AuctionSystemApp.Domain.Services
{
    public class OtpService : IOtpService
    {
        private readonly IRepository<UserOTP> _otpRepository;
        public OtpService(IRepository<UserOTP> otpRepository)
        {
            _otpRepository = otpRepository;
        }
        public static string Generate()
        {
            Random rnd = new Random();
            return rnd.Next().ToString().Substring(0, 6);
        }

        public async Task<UserOTP> CreateUserOTP(int userId)
        {
            UserOTP userOTP = UserOTPFactory.CreateUserOTP(userId);
            await _otpRepository.AddAsync(userOTP);
            return userOTP;
        }

        public async Task<UserOTP?> GetOtpByUserId(int userId)
        {
            UserOTP? userOTP = await _otpRepository.GetById(userId);
            return userOTP;
        }

        public async Task<bool> UpdateUserOTP(UserOTP userOTP)
        {
            bool result = await _otpRepository.UpdateAsync(userOTP);
            return result;
        }

        public async Task<bool> VerfiyOTP(string Otp, int userId)
        {
            UserOTP? userOTP = await _otpRepository.GetById(userId);
            if (userOTP == null)
                return false;

            return Otp == userOTP.OTP;
        }
    }
}
