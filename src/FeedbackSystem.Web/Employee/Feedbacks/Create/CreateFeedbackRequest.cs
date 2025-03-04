using System.ComponentModel.DataAnnotations;

namespace FeedbackSystem.Web.Employee.Feedbacks.Create;

public class CreateFeedbackRequest
{
  public const string Route = "Employee/Feedbacks";
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? Email { get; set; }

  public int BranchId { get; set; }
  [Required] public string Comment { get; set; } = null!;
  public IFormFile? UploadFile { get; set; }
}
