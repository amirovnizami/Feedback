using System.Text.Json;
using AutoWrapper;
using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.Core.Services;
using FeedbackSystem.Core.Services.Helper;
using FeedbackSystem.Infrastructure;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using FeedbackSystem.Web.Configurations;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

MapperConfig.ConfigureMapper(builder.Services);

builder.Services.AddControllers(options =>
{
  options.Filters.Add(new AuthorizeFilter());
});
builder.Services.AddControllers()
  .AddJsonOptions(options =>
  {
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
  });

builder.Services.AddJwtAuthentication(builder.Configuration);
var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
  .CreateLogger();

logger.Information("Starting web host");

var appLogger = new SerilogLoggerFactory(logger)
  .CreateLogger<Program>();

builder.Services.AddTransient<IManageFileService, ManageFileService>();
builder.Services.AddOptionConfigs(builder.Configuration, appLogger, builder);
builder.Services.AddServiceConfigs(appLogger, builder);
builder.Services.AddFastEndpoints()
  .SwaggerDocument(o =>
  {
    o.ShortSchemaNames = true;
  });


builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.Configure<FormOptions>(options =>
{
  options.MultipartBodyLengthLimit = 10 * 1024 * 1024;
});
builder.Services.AddFastEndpoints();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
  options.AddPolicy("ReactClient", policy =>
  {
    policy.WithOrigins("http://localhost:5173")
      .AllowAnyHeader()
      .AllowAnyMethod()
      .AllowCredentials();
  });
});
builder.Services.AddSwaggerGen(c =>
{
  c.MapType<IFormFile>(() => new OpenApiSchema { Type = "string", Format = "binary" });
});


var app = builder.Build();


app.UseCors("ReactClient");

// SignalR endpoint-i
app.MapHub<ChatHub>("/chatHub");

Common.Initialize(builder.Configuration);
app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions()
{
  IgnoreNullValue = false,
  ShowStatusCode = true,
  ShowIsErrorFlagForSuccessfulResponse = true,
  IsDebug = true, //TODO This property must false in Production
  EnableExceptionLogging = false,
  EnableResponseLogging = false,
  LogRequestDataOnException = false,
  ShouldLogRequestData = false,
  ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
  UseCustomExceptionFormat = false,
  ExcludePaths =
  [
    new AutoWrapperExcludePath("(?i).*download*.", ExcludeMode.Regex),
  ]
});
app.UseStaticFiles();
app.UseFastEndpoints();
await app.UseAppMiddlewareAndSeedDatabase();
app.Run();


public partial class Program
{
}
