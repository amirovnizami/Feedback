using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.UseCases.Comments;

namespace FeedbackSystem.UseCases.Feedbacks;

public record FeedbackDto(
  string loginId,
  string? firstName,
  string? lastName,
  string? email,
  int branchId,
  int ?statusId,
  DateOnly createdDate,
  IEnumerable<CommentDto> comments)
{
}
