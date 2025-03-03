using System.ComponentModel.DataAnnotations;
using FeedbackSystem.Core.CategoryAggregate;

namespace FeedbackSystem.Web.Branchs.Create;

public class CreateBranchRequest
{
  public const string Route = "Admin/Branches";

  [Required] public string? Name { get; set; }
  public int CategoryId { get; set; }
}
