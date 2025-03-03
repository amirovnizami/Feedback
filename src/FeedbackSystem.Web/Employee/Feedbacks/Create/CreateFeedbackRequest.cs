using System.ComponentModel.DataAnnotations;
using YamlDotNet.Core.Tokens;
using Comment = FeedbackSystem.Core.CommentAggregate.Comment;

namespace FeedbackSystem.Web.Feedbacks.Create;

public class CreateFeedbackRequest
{
  public const string Route = "Employee/Feedbacks";
  [Required] public string? FirstName { get; set; }
  [Required] public string? LastName { get; set; }
  [Required] public string? Email { get; set; }

  public int BranchId { get; set; }
  public string Comment { get; set; } = null!;
  public IFormFile? UploadFile { get; set; }
  
}
