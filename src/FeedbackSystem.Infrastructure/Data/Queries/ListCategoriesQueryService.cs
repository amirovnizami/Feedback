using FeedbackSystem.Core.CategoryAggregate;
using FeedbackSystem.Core.CategoryAggregate.Specifications;
using FeedbackSystem.UseCases.Categories.List;

namespace FeedbackSystem.Infrastructure.Data.Queries;

public class ListCategoriesQueryService(AppDbContext db) : IListCategoryQueryService
{
  public Task<List<Category>> ListAsync(CategoryListSpec categoryListSpec)
  {
    return db.Categories.ToListAsync(categoryListSpec);
  }
}
