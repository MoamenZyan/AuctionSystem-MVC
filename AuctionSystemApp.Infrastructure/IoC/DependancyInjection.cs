using AuctionSystemApp.Application.ApplicationServices;
using AuctionSystemApp.Application.Interfaces;
using AuctionSystemApp.Application.Interfaces.StrategiesInterfaces;
using AuctionSystemApp.Domain.Entities;
using AuctionSystemApp.Domain.Interfaces.RepositoriesInterfaces;
using AuctionSystemApp.Domain.Interfaces.ServicesInterfaces;
using AuctionSystemApp.Domain.Services;
using AuctionSystemApp.Infrastructure.AuthenticationOptions;
using AuctionSystemApp.Infrastructure.Configurations;
using AuctionSystemApp.Infrastructure.Data;
using AuctionSystemApp.Infrastructure.Interfaces;
using AuctionSystemApp.Infrastructure.Repositories;
using AuctionSystemApp.Infrastructure.Services;
using AuctionSystemApp.Infrastructure.Services.EmailService;
using AuctionSystemApp.Infrastructure.Services.EmailService.EmailStrategies;
using AuctionSystemApp.Infrastructure.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid;

namespace AuctionSystemApp.Infrastructure.IoC
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<JwtBearerConfigurations>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                var jwtBearerConfigurations = services.BuildServiceProvider().GetRequiredService<JwtBearerConfigurations>();
                jwtBearerConfigurations.ConfigureJwtBearerOptions(options);
            });

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"))
                );

            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<ICommentAppService, CommentAppService>();
            services.AddScoped<IAuctionAppService, AuctionAppService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuctionService, AuctionService>();
            services.AddScoped<IFileSystem, PhotoService>();
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<IJunctionRepository<AuctionUser>, AuctionUserRepository>();
            services.AddScoped<ICommentService, CommentService>();

            services.Configure<JwtConfiguration>(configuration.GetSection("JwtConfigurations"));
            services.Configure<SendGridConfigurations>(configuration.GetSection("SendGridConfigurations"));
            services.AddScoped<IJwtService, JwtService>();

            services.AddScoped<IWelcomeEmailStrategy, WelcomeEmailStrategy>();
            services.AddScoped<IOtpEmailStrategy, OtpEmailStrategy>();
            services.AddScoped<INotificationContext, NotificationContext>();
            services.AddScoped<IUserVerifiedEmailStrategy, UserVerifiedEmailStrategy>();
            services.AddScoped<IUserJoinedAuctionEmailStrategy, UserJoinedAuctionEmailStrategy>();
            services.AddScoped<IUserAddedCommentOnAuctionEmailStrategy, UserAddedCommentOnAuctionEmailStrategy>();

            services.AddScoped<IRepository<Auction>, AuctionRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<UserOTP>, UserOTPRepository>();
            services.AddScoped<IRepository<Comment>, CommentRepository>();

            return services;
        }
    }
}
