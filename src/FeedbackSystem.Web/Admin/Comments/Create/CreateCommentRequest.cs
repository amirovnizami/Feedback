namespace FeedbackSystem.Web.Admin.Comments.Create;

public class CreateCommentRequest
{
  public const string Route = "Admin/Comments";
  public string loginId { get; set; } = null!;
  public string Comment { get; set; } = null!;
  public IFormFile? UploadFile { get; set; }
}
