using AuctionSystemApp.Domain.Entities;
using AuctionSystemApp.Domain.Services;


namespace AuctionSystemApp.Domain.Factories
{
    public class UserOTPFactory
    {
        public static UserOTP CreateUserOTP(int UserId)
        {
            UserOTP userOTP = new UserOTP()
            {
                UserId = UserId,
                OTP = OtpService.Generate(),
                Deadline = DateTime.UtcNow.AddMinutes(10)
            };
            return userOTP;
        }
    }
}
