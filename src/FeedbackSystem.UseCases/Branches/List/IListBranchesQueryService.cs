using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.Core.BranchAggregate.Specifications;

namespace FeedbackSystem.UseCases.Branches.List;

public interface IListBranchesQueryService
{
  Task<List<Branch>> ListAsync(BranchListSpec branchListSpec);
}
