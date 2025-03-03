namespace FeedbackSystem.Core.CommentAggregate.Specifications
{
  public class CommentListSpec : Specification<Comment>
  {
    public CommentListSpec(int feedbackId, int? userId)
    {
      Query.Where(comment => comment.FeedbackId == feedbackId &&
                             (userId == null || comment.UserId == userId));
    }
  }
}
