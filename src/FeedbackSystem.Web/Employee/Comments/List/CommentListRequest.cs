namespace FeedbackSystem.Web.Employee.Comments.List;

public class CommentListRequest
{
  public const string Route = "Employee/Comments";

  public string loginId { get; set; } = null!;
}
