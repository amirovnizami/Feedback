using System.ComponentModel.DataAnnotations;
using FeedbackSystem.Core.CategoryAggregate;

public class BrancListRequest
{
  public const string Route = "Employee/Branches";

  public string? Name { get; set; } = null;
  public int? CategoryId { get; set; } = null;
}
