﻿using Ardalis.ListStartupServices;
using AutoMapper;
using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.StatusAgrregate;
using FeedbackSystem.Infrastructure.Email;
using FeedbackSystem.UseCases.Branches;
using FeedbackSystem.UseCases.Comments;
using FeedbackSystem.UseCases.Statuses;

namespace FeedbackSystem.Web.Configurations;

public static class OptionConfigs
{
  public static IServiceCollection AddOptionConfigs(this IServiceCollection services,
    IConfiguration configuration,
    Microsoft.Extensions.Logging.ILogger logger,
    WebApplicationBuilder builder)
  {

    var config = new MapperConfiguration(cfg =>
    {
      cfg.CreateMap<BranchDto, Branch>();
      cfg.CreateMap<StatusDto, Status>()
        .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.StatusName))
        .ConstructUsing(src => new Status(src.id, src.StatusName));
      cfg.CreateMap<CommentDto, Comment>()
        .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text));
    });

    var mapper = new Mapper(config);


    services.Configure<MailserverConfiguration>(configuration.GetSection("Mailserver"))
      // Configure Web Behavior
      .Configure<CookiePolicyOptions>(options =>
      {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

    if (builder.Environment.IsDevelopment())
    {
      // add list services for diagnostic purposes - see https://github.com/ardalis/AspNetCoreStartupServices
      services.Configure<ServiceConfig>(config =>
      {
        config.Services = new List<ServiceDescriptor>(builder.Services);

        // optional - default path to view services is /listallservices - recommended to choose your own path
        config.Path = "/listservices";
      });
    }

    logger.LogInformation("{Project} were configured", "Options");

    return services;
  }
}
