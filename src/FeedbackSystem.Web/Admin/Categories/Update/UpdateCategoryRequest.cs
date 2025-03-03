using System.ComponentModel.DataAnnotations;

namespace FeedbackSystem.Web.Categories.Update;

public class UpdateCategoryRequest
{
  public const string Route = "Admin/Categories/{CategoryId:int}";
  public static string BuildRoute(int categoryId) => Route.Replace("{CategoryId:int}", categoryId.ToString());
  [Required] public int CategoryId { get; set; }
  [Required] public string? Name { get; set; }
}
