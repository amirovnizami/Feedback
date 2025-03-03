using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.UseCases.Branches;
using FeedbackSystem.UseCases.Branches.Update;

namespace FeedbackSystem.UseCases.Contributors.Update;

public class UpdateBranchHandler(IRepository<Branch> _repository)
  : ICommandHandler<UpdateBranchCommand, Result<BranchDto>>
{
  public async Task<Result<BranchDto>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
  {
    var exisitingBranch = await _repository.GetByIdAsync(request.BranchId, cancellationToken);
    if (exisitingBranch == null)
    {
      return Result.NotFound();
    }

    exisitingBranch.UpdateName(request.NewName!);

    await _repository.UpdateAsync(exisitingBranch, cancellationToken);

    return new BranchDto(exisitingBranch.Id,
      exisitingBranch.Name, exisitingBranch.CategoryId);
  }
}
