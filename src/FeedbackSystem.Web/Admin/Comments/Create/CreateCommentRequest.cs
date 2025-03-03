namespace FeedbackSystem.Web.Admin.Comments.Create;

public class CreateCommentRequest
{
  public const string Route = "Admin/Comments";
  public int feedbackId { get; set; }
  public string Comment { get; set; } = null!;
  public IFormFile? UploadFile { get; set; }
}
