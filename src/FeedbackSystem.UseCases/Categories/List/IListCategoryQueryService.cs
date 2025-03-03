using FeedbackSystem.Core.CategoryAggregate;
using FeedbackSystem.Core.CategoryAggregate.Specifications;

namespace FeedbackSystem.UseCases.Categories.List;

public interface IListCategoryQueryService
{
  Task<List<Category>> ListAsync(CategoryListSpec categoryListSpec);
}
