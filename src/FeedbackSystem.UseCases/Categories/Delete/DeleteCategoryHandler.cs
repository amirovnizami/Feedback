using FeedbackSystem.Core.CategoryAggregate;
using FeedbackSystem.Core.CategoryAggregate.Specifications;
using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.UseCases.Branches.Delete;

namespace FeedbackSystem.UseCases.Categories.Delete;

public class DeleteCategoryHandler(IRepository<Category> _repository)
  : ICommandHandler<DeleteCategoryCommand, Result>
{
  public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
  {
    var exisitingCategory = await _repository.GetByIdAsync(request.categoryId);
    if (exisitingCategory == null) return Result.NotFound("Category not found");

    await _repository.DeleteAsync(exisitingCategory);
    return Result.Success();
    // Another Approach: Do the real work here including dispatching domain events - change the event from internal to public
    // @ardalis prefers using the service above so that **domain** event behavior remains in the **domain model** (core project)
    // var aggregateToDelete = await _repository.GetByIdAsync(request.ContributorId);
    // if (aggregateToDelete == null) return Result.NotFound();
    // await _repository.DeleteAsync(aggregateToDelete);
    // var domainEvent = new ContributorDeletedEvent(request.ContributorId);
    // await _mediator.Publish(domainEvent);// return Result.Success();
  }
}
