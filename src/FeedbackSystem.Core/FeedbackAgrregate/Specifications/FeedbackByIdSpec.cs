namespace FeedbackSystem.Core.FeedbackAgrregate.Specifications;

public sealed class FeedbackByIdSpec : Specification<Feedback>
{
  public FeedbackByIdSpec(int id)
  {
    Query.Include(f => f.Comments);
    Query.Where(f => f.Id == id);
  }
}
