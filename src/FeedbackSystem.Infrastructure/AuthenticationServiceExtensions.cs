using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FeedbackSystem.Infrastructure.Extensions
{
  public static class AuthenticationServiceExtensions
  {
    public static IServiceCollection AddJwtAuthentication(
      this IServiceCollection services,
      IConfiguration configuration)
    {
      var secretKey = configuration["AppSettings:Secret"]
                      ?? throw new ArgumentNullException("Secret key is missing in configuration");

      services.AddAuthentication(options =>
        {
          options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
          options.RequireHttpsMetadata = false;
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuer = true,
            ValidIssuer = "amirovnizami",
            ValidateAudience = true,
            ValidAudience = "your-audience",
            ValidAudiences = new[] { "a", "b" },
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ValidateLifetime = true
          };
        });

      return services;
    }
  }
}
