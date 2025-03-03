using FeedbackSystem.Core.FeedbackAgrregate;

public sealed class FeedbackByIdSpec : Specification<Feedback>
{
  public FeedbackByIdSpec(int id)
  {
    Query.Include(f => f.Comments)
      .ThenInclude(c => c.User);
    Query.Where(f => f.Id == id);
  }
}
