using Ganss.Xss;
using AuctionSystemApp.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace AuctionSystemApp.Domain.Factories
{
    public class UserFactory
    {
        static HtmlSanitizer sanitizer = new HtmlSanitizer();
        public static User CreateUser(Dictionary<string, string> userInfo)
        {
            User user = new User()
            {
                Fname = sanitizer.Sanitize(userInfo["Fname"]!),
                Lname = sanitizer.Sanitize(userInfo["Lname"]!),
                Email = sanitizer.Sanitize(userInfo["Email"]!),
                Phone = sanitizer.Sanitize(userInfo["Phone"]!),
                PhotoPath = userInfo["PhotoPath"]
            };

            return user;
        }
    }
}
