using System.ComponentModel.DataAnnotations;
using FeedbackSystem.Core.CategoryAggregate;

namespace FeedbackSystem.Web.Admin.Branches;

public class BrancListRequest
{
  public const string Route = "Admin/Branches";

  public string? Name { get; set; } = null;
  public int? CategoryId { get; set; } = null;
}
