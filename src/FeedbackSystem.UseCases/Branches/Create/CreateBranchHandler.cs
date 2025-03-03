using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.UseCases.Contributors.Create;

// using FeedbackSystem.Core.BranchAggregate;

namespace FeedbackSystem.UseCases.Branches.Create;

public class CreateBranchHandler(IRepository<Branch> _repository)
  : ICommandHandler<CreateBranchCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateBranchCommand request,
    CancellationToken cancellationToken)
  {
    var existingBranch = await _repository.FirstOrDefaultAsync(
      new BranchByNameSpec(request.Name), cancellationToken);
    if (existingBranch is not null)
    {
      return Result.Error("Branch already exists");
    }

    var newBranch = new Branch(request.Name, request.CategoryId);

    var createdItem = await _repository.AddAsync(newBranch, cancellationToken);

    return Result.Success(createdItem.Id);
  }
}
