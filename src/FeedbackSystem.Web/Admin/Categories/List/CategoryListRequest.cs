namespace FeedbackSystem.Web.Categories.List;

public class CategoryListRequest
{
  public const string Route = "Admin/Categories";

  public int? Id { get; set; } = null;
  public string? Name { get; set; } = null;
}
