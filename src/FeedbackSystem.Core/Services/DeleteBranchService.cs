using FeedbackSystem.Core.BranchAggregaet.Events;
using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.Core.Interfaces;


namespace FeedbackSystem.Core.Services;

public class DeleteBranchService(
  IRepository<Branch> _repository,
  IMediator _mediator,
  ILogger<DeleteBranchService> _logger) : IDeleteBranchService
{
  public async Task<Result> DeleteBranch(int branchId)
  {
    _logger.LogInformation("Deleting Branch {branchId}", branchId);
    Branch? aggregateToDelete = await _repository.GetByIdAsync(branchId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new BranchDeletedEvent(branchId);
    await _mediator.Publish(domainEvent);

    return Result.Success();
  }
}
