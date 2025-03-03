namespace FeedbackSystem.Core.CategoryAggregate.Specifications;

public class CategoryListSpec : Specification<Category>
{
  public CategoryListSpec(int? id, string? name)
  {
    var searchText = name ?? string.Empty;
    Query.Where(category => category.Name.ToLower().Contains(searchText) || category.Id == id);
  }
}
