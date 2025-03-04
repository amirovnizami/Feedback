

namespace FeedbackSystem.Core.CommentAggregate.Specification;

public class CommentByLoginId:Specification<Comment>
{
  public CommentByLoginId(string id)
  {
    Query.Include(c => c.Feedback);
    Query.Where(c => c.Feedback.LoginId == id && c.IsAdmin == false);
  }
}
