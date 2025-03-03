using FeedbackSystem.Core.FeedbackAgrregate;

namespace FeedbackSystem.Core.BranchAggregaet.Specifications;

public sealed class FeedbackByNameSpec : Specification<Feedback>
{
  public FeedbackByNameSpec(string name)
  {
    Query.Where(f => f.FirstName == name);
  }
}
