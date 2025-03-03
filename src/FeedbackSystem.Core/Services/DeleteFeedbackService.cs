using FeedbackSystem.Core.FeedbackAgrregate.Events;
using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.Core.FeedbackAgrregate;

namespace FeedbackSystem.Core.Services;

public class DeleteFeedbackService(
  IRepository<Feedback> _repository,
  IMediator _mediator,
  ILogger<DeleteBranchService> _logger) : IDeleteFeedbackService
{
  public async Task<Result> DeleteFeedback(int id)
  {
    _logger.LogInformation("Deleting Feedback {branchId}", id);
    Feedback? aggregateToDelete = await _repository.GetByIdAsync(id);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new FeedbackDeletedEvent(id);
    await _mediator.Publish(domainEvent);

    return Result.Success();
  }
}
