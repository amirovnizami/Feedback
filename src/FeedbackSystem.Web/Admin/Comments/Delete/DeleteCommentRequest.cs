namespace FeedbackSystem.Web.Admin.Comments.Delete;

public class DeleteCommentRequest
{
  public const string Route = "Admin/Comments/{FeedbackId:int}";
  public static string BuildRoute(int feedbackId) => Route.Replace("{FeedbackId:int}", feedbackId.ToString());

  public int FeedbackId { get; set; }
}
