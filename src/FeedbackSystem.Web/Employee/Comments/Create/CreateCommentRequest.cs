namespace FeedbackSystem.Web.Employee.Comments.Create;

public class CreateCommentRequest
{
  public const string Route = "Employee/Comments";
  public string loginId { get; set; } = null!;
  public string Comment { get; set; } = null!;
  public IFormFile? File { get; set; }

}


