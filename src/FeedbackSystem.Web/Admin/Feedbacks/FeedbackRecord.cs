using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.UseCases.Comments;

public record FeedbackRecord(
  string loginId,
  string? firstname,
  string? lastname,
  string? email,
  int? branchId,
  int?statusId,
  DateOnly date,
  IEnumerable<CommentDto> Comments)
{
}
