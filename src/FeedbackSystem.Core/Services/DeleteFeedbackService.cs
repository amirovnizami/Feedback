using FeedbackSystem.Core.FeedbackAgrregate.Events;
using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.Core.FeedbackAgrregate;
using FeedbackSystem.Core.FeedbackAgrregate.Specifications;

namespace FeedbackSystem.Core.Services;

public class DeleteFeedbackService(
  IRepository<Feedback> _repository,
  IMediator _mediator,
  ILogger<DeleteBranchService> _logger) : IDeleteFeedbackService
{
  public async Task<Result> DeleteFeedback(string loginId)
  {
    var spec = new FeedbackByLoginId(loginId);
    _logger.LogInformation("Deleting Feedback {loginId}",loginId);
    Feedback? aggregateToDelete = await _repository.FirstOrDefaultAsync(spec, CancellationToken.None);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new FeedbackDeletedEvent(aggregateToDelete.Id);
    await _mediator.Publish(domainEvent);

    return Result.Success();
  }

 
}
