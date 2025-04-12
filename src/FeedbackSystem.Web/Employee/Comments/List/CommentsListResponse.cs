using AutoWrapper;

namespace FeedbackSystem.Web.Employee.Comments.List;

public class CommentsListResponse
{
  public List<CommentRecord> Comments { get; set; } = [];
  public string?  ErrorMessage { get; set; } 
}
