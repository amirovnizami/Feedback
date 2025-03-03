namespace FeedbackSystem.Core.BranchAggregaet.Specifications;

public sealed class BranchByNameSpec : Specification<Branch>
{
  public BranchByNameSpec(string name)
  {
    Query.Where(b => b.Name == name);
  }
}
