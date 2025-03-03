using FeedbackSystem.Core.CategoryAggregate;

namespace FeedbackSystem.UseCases.Branches.List;

public record ListBranchesQuery(string? Name, int? Category, int? Skip, int? Take) : IQuery<Result<List<BranchDto>>>
{
}
