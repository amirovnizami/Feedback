namespace FeedbackSystem.Core.CategoryAggregate.Events;

internal sealed class CategoryDeleteEvent(int categoryId) : DomainEventBase
{
  public int CategoryId { get; init; } = categoryId;
}
