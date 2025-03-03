using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.Core.Services;
using FeedbackSystem.Infrastructure.Authentication;
using FeedbackSystem.Infrastructure.Data;
using FeedbackSystem.Infrastructure.Data.Queries;
using FeedbackSystem.Infrastructure.User;
using FeedbackSystem.UseCases.Branches.List;
using FeedbackSystem.UseCases.Categories.List;
using FeedbackSystem.UseCases.Comments.Admin.Comments.List;
using FeedbackSystem.UseCases.Feedbacks.List;
using FeedbackSystem.UseCases.Security;
using FeedbackSystem.UseCases.Statuses.List;

namespace FeedbackSystem.Infrastructure;

public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connectionString = config.GetConnectionString("DefaultConnection");
    // Guard.Against.Null(connectionString);
    services.AddDbContext<AppDbContext>(options =>
      options.UseSqlServer(connectionString));

    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
      .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>))
      .AddScoped<IListBranchesQueryService, ListBranchesQueryService>()
      .AddScoped<IDeleteBranchService, DeleteBranchService>()
      .AddScoped<IDeleteFeedbackService, DeleteFeedbackService>()
      .AddScoped<IListCategoryQueryService, ListCategoriesQueryService>()
      .AddScoped<IListFeedbackQueryService, ListFeedbacksQueryService>()
      .AddScoped<IListCommentQueryService, ListCommentsQueryService>()
      .AddScoped<IListStatusQueryService, ListStatusQueryService>()
      .AddScoped<IDeleteCategoryService, DeleteCategoryService>()
      .AddScoped<IIdGeneratorService, IdGeneratorService>()
      .AddSingleton<ITokenService, TokenService>()
      .AddScoped<IUserContext, HttpUserContext>();

    // .AddScoped<IUserContext, HttpUserContext>();

    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
