namespace FeedbackSystem.Web.Employee.Comments.Delete;

public class DeleteCommentRequest
{
  public const string Route = "Employee/Comments/{LoginId}/{UserId}";
  public string LoginId { get; init; } = string.Empty;
  // public int UserId { get; set; } 
}
