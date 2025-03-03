using FeedbackSystem.Core.CategoryAggregate;
using FeedbackSystem.Core.CategoryAggregate.Events;
using FeedbackSystem.Core.Interfaces;

namespace FeedbackSystem.Core.Services;

public class DeleteCategoryService(
  IRepository<Category> _repository,
  IMediator _mediator,
  ILogger<DeleteCategoryService> _logger) : IDeleteCategoryService
{
  public async Task<Result> DeleteCategory(int categoryId)
  {
    _logger.LogInformation($"DeleteCategoryService - categoryId: {categoryId}");
    Category? aggregateToDelete = await _repository.GetByIdAsync(categoryId);
    if (aggregateToDelete == null)
    {
      return Result.NotFound();
    }

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new CategoryDeleteEvent(categoryId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
