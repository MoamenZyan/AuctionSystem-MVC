using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System.Text;
using AuctionSystemApp.Infrastructure.Configurations;

namespace AuctionSystemApp.Infrastructure.AuthenticationOptions
{
    public class JwtBearerConfigurations
    {
        private readonly JwtConfiguration _jwtConfiguration;
        public JwtBearerConfigurations(IOptions<JwtConfiguration> jwtConfiguration)
        {
            _jwtConfiguration = jwtConfiguration.Value;
        }
        public void ConfigureJwtBearerOptions(JwtBearerOptions options)
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = _jwtConfiguration.Issuer,

                ValidateAudience = true,
                ValidAudience = _jwtConfiguration.Audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.SigningKey)),

                ValidateLifetime = true,
            };

            options.Events = new JwtBearerEvents()
            {
                OnMessageReceived = context =>
                {
                    var token = context.HttpContext.Request.Cookies["AuthJwt"];
                    if (!string.IsNullOrEmpty(token))
                    {
                        context.Token = token;
                    }

                    return Task.CompletedTask;
                }
            };
        }
    }
}
