namespace FeedbackSystem.Core.CategoryAggregate.Specifications;

public sealed class CategoryByIdSpec : Specification<Category>
{
  public CategoryByIdSpec(int categoryId)
  {
    Query.Where(branch => branch.Id == categoryId);
  }
}
