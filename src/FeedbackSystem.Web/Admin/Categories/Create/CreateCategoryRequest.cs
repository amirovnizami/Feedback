using System.ComponentModel.DataAnnotations;

namespace FeedbackSystem.Web.Categories.Create;

public class CreateCategoryRequest
{
  public const string Route = "Admin/Categories";
  [Required] public string? Name { get; set; }
}
