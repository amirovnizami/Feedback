namespace FeedbackSystem.UseCases.Branches.Get;

public record GetBranchQuery(int BranchId) : IQuery<Result<BranchDto>>;
