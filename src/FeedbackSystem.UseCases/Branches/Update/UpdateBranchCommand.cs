using FeedbackSystem.Core.BranchAggregaet.Specifications;

namespace FeedbackSystem.UseCases.Branches.Update;

public record UpdateBranchCommand(int BranchId, string? NewName) : ICommand<Result<BranchDto>>
{
}
