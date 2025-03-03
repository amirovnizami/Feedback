namespace FeedbackSystem.Web.Admin.Comments.Delete;

public class DeleteCommentRequest
{
  public const string Route = "Admin/Comments/{FeedbackId}";
  public int FeedbackId { get; init; }
}
