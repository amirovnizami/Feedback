namespace FeedbackSystem.Core.CategoryAggregate.Specifications;

public class CategoryByNameSpec : Specification<Category>
{
  public CategoryByNameSpec(string name)
  {
    Query.Where(c => c.Name == name.ToLower());
  }
}
