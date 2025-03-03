using Ardalis.SharedKernel;
using System.Reflection;
using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.Core.CategoryAggregate;
using FeedbackSystem.UseCases.Categories.Create;
using FeedbackSystem.UseCases.Contributors.Create;
using FeedbackSystem.UseCases.Feedbacks.Create;

namespace FeedbackSystem.Web.Configurations;

public static class MediatrConfigs
{
  public static IServiceCollection AddMediatrConfigs(this IServiceCollection services)
  {
    var mediatRAssemblies = new[]
    {
      Assembly.GetAssembly(typeof(Category)), Assembly.GetAssembly(typeof(CreateCategoryCommand)),
      Assembly.GetAssembly(typeof(Branch)), Assembly.GetAssembly(typeof(CreateBranchCommand)),
      Assembly.GetAssembly(typeof(Feedback)), Assembly.GetAssembly(typeof(CreateFeedbackCommand)),
    };

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!))
      .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
      .AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
    return services;
  }
}
