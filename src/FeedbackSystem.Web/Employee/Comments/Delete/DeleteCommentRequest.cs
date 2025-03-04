namespace FeedbackSystem.Web.Employee.Comments.Delete;

public class DeleteCommentRequest
{
  public const string Route = "Employee/Comments/{LoginId}";
  public string LoginId { get; init; } = string.Empty;
}
