using FeedbackSystem.UseCases.Statuses;

namespace FeedbackSystem.UseCases.Feedbacks.List;

public record ListFeedbackQuery(
  int? id,
  string? firstname,
  string? lastname,
  int? branchId,
  int? statusId,
  int? Skip,
  int? Take) : IQuery<Result<List<FeedbackDto>>>
{
}
