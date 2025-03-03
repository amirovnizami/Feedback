

using FeedbackSystem.Core.CommentAggregate;

public class CommentByLoginId:Specification<Comment>
{
  public CommentByLoginId(string id)
  {
    Query.Include(f => f.Feedback);
    Query.Where(f => f.Feedback.LoginId == id);
  }
}
