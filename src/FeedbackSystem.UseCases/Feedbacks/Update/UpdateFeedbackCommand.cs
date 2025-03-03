using FeedbackSystem.Core.CommentAggregate;

namespace FeedbackSystem.UseCases.Feedbacks.Update;

public record UpdateFeedbackCommand(int id, int BranchId, int StatusId, Comment Comment) : ICommand<Result<FeedbackDto>>
{
}
