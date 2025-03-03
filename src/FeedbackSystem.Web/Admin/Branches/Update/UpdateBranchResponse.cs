using FeedbackSystem.Core.BranchAggregaet.Specifications;

namespace FeedbackSystem.Web.Branches.Update;

public class UpdateBranchResponse(BranchRecord branch)
{
  public BranchRecord Branch { get; set; } = branch;
}
