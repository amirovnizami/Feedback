using FeedbackSystem.Core.CategoryAggregate;

namespace FeedbackSystem.Core.BranchAggregaet.Specifications;

public sealed class BranchListSpec : Specification<Branch>
{
  public BranchListSpec(string? name, int? categoryId)
  {
    var searchText = name ?? string.Empty;
    Query.Where(branch => branch.Name.ToLower().Contains(searchText) || branch.CategoryId == categoryId);
  }
}
