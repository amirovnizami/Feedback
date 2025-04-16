using Ardalis.ListStartupServices;
using Microsoft.EntityFrameworkCore;
using FeedbackSystem.Infrastructure.Data;

namespace FeedbackSystem.Web.Configurations;

public static class MiddlewareConfig
{
  public static async Task<IApplicationBuilder> UseAppMiddlewareAndSeedDatabase(this WebApplication app)
  {
    if (app.Environment.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      app.UseShowAllServicesMiddleware();
    }
    else
    {
      app.UseDefaultExceptionHandler();
      app.UseHsts();
    }

    app.UseCors("AllowAll");

    // app.UseAuthentication();
    // app.UseAuthorization(); 

     app.UseSwaggerGen();

    app.UseMiddleware<UnauthorizedMiddleware>();
    app.MapHub<ChatHub>("/chatHub");
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseHttpsRedirection();

    await SeedDatabase(app);

    return app;
  }

  static async Task SeedDatabase(WebApplication app)
  {
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    try
    {
      var context = services.GetRequiredService<AppDbContext>();
      await context.Database.MigrateAsync();
      await SeedData.InitializeAsync(context);
    }
    catch (Exception ex)
    {
      var logger = services.GetRequiredService<ILogger<Program>>();
      logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
    }
  }
}
