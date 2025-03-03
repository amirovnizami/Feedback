using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.Core.Interfaces;

namespace FeedbackSystem.UseCases.Branches.Delete;

public class DeleteBranchHandler(IDeleteBranchService deleteBranchService,IRepository<Branch> repository )
  : ICommandHandler<DeleteBranchCommand, Result>
{
  public async Task<Result> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
  {
    var specification = new BranchByIdSpec(request.BranchId);
      var exisitingBranch = await repository.FirstOrDefaultAsync(specification, cancellationToken);
      if (exisitingBranch == null)
      {
        return Result.NotFound("Branch not found");
      }
    return await deleteBranchService.DeleteBranch(request.BranchId);
  }
    
}
