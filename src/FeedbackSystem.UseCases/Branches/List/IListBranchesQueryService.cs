using FeedbackSystem.Core.BranchAggregaet.Specifications;

namespace FeedbackSystem.UseCases.Branches.List;

public interface IListBranchesQueryService
{
  Task<List<Branch>> ListAsync(BranchListSpec branchListSpec);
}
