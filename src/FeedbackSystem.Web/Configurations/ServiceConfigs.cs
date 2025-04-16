using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.Infrastructure;
using FeedbackSystem.Infrastructure.Email;

namespace FeedbackSystem.Web.Configurations;

public static class ServiceConfigs
{
  public static IServiceCollection AddServiceConfigs(this IServiceCollection services,
    Microsoft.Extensions.Logging.ILogger logger, WebApplicationBuilder builder)
  {
    builder.Services.AddCors(options =>
    {
      options.AddDefaultPolicy(policy =>
      {
        policy.WithOrigins("http://localhost:3000") // React üçün
          .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials();
      });
    });
    builder.Services.AddSignalR();
    builder.Services.AddAuthentication();
    builder.Services.AddAuthorization();
    services.AddInfrastructureServices(builder.Configuration, logger)
      .AddMediatrConfigs();
    builder.Services.AddCors(options =>
    {
      options.AddPolicy("AllowAll",
        policy =>
        {
          policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
    });


    if (builder.Environment.IsDevelopment())
    {
      // Use a local test email server
      // See: https://ardalis.com/configuring-a-local-test-email-server/
      services.AddScoped<IEmailSender, MimeKitEmailSender>();

      // Otherwise use this:
      //builder.Services.AddScoped<IEmailSender, FakeEmailSender>();
    }
    else
    {
      services.AddScoped<IEmailSender, MimeKitEmailSender>();
    }

    logger.LogInformation("{Project} services registered", "Mediatr and Email Sender");

    return services;
  }
}
