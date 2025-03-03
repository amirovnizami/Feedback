namespace FeedbackSystem.Core.FeedbackAgrregate.Events;

public class FeedbackDeletedEvent(int id) : DomainEventBase
{
  public int Id { get; set; } = id;
}
