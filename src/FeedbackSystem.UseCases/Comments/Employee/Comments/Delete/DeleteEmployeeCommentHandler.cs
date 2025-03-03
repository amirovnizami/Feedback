using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.CommentAggregate.Specifications;
using FeedbackSystem.Core.FeedbackAgrregate.Specifications;

namespace FeedbackSystem.UseCases.Comments.Delete;

public class DeleteEmployeeCommentHandler(IRepository<Comment> _repository, IRepository<Feedback> _feedbackRepository)
  : ICommandHandler<DeleteEmployeeCommentCommand, Result>
{
  public async Task<Result> Handle(DeleteEmployeeCommentCommand request, CancellationToken cancellationToken)
  {
    var feedBackSpec = new FeedbackByLoginId(request.loginId);
    var feedback = await _feedbackRepository.FirstOrDefaultAsync(feedBackSpec, cancellationToken);
    if (feedback == null)
    {
      return Result.NotFound("Feedback not found");
    }
    var commentsSpec = new CommentListSpec(feedback.Id,null);
    var comments = await _repository.ListAsync(commentsSpec, cancellationToken);

    if (comments == null || !comments.Any())
    {
      return Result.NotFound("Comment not found");
    }

    await _repository.DeleteRangeAsync(comments, cancellationToken);

    return Result.Success();
  }
}
