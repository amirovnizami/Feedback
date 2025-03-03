namespace FeedbackSystem.Core.BranchAggregaet.Events;

internal sealed class BranchDeletedEvent(int branchId) : DomainEventBase
{
  public int BranchId { get; init; } = branchId;
}
