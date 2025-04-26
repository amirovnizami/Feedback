using Ardalis.Specification;

namespace FeedbackSystem.Core.FeedbackAgrregate.Specifications;

public sealed class FeedbackListSpec : Specification<Feedback>
{
  public FeedbackListSpec()
  {
      Query.Include(f => f.Comments);
    }
}
