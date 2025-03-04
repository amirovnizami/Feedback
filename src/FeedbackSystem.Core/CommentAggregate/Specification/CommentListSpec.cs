namespace FeedbackSystem.Core.CommentAggregate.Specification
{
  public sealed class CommentListSpec : Specification<Comment>
  {
    public CommentListSpec(int feedbackId,bool isAdmin)
    {
      Query.Where(comment => comment.FeedbackId == feedbackId &&
                             (isAdmin == comment.IsAdmin));
    }
  }
}
