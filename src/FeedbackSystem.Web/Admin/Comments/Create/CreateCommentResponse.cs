namespace FeedbackSystem.Web.Admin.Comments.Create;

public class CreateCommentResponse(int feedbackId, string comment)
{
  public int feedbackId { get; set; } = feedbackId;
  public string Comment { get; set; } = comment;
  public DateTime CreatedDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
}
