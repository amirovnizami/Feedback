using FeedbackSystem.Core.CategoryAggregate;

namespace FeedbackSystem.Core.Interfaces;

public interface IDeleteCategoryService
{
  public Task<Result> DeleteCategory(int categoryId);
}
