using FeedbackSystem.Core.CategoryAggregate;

namespace FeedbackSystem.Web.Categories.Update;

public class UpdateCategoryResponse(CategoryRecord category)
{
  public CategoryRecord Category { get; set; } = category;
}
