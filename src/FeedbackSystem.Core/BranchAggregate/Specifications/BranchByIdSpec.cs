namespace FeedbackSystem.Core.BranchAggregaet.Specifications;

public sealed class BranchByIdSpec : Specification<Branch>
{
  public BranchByIdSpec(int branchId)
  {
    Query.Where(branch => branch.Id == branchId);
  }
}
