using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.CommentAggregate.Specification;
using FeedbackSystem.Core.FeedbackAgrregate.Specifications;
using FeedbackSystem.UseCases.Comments.Delete;

namespace FeedbackSystem.UseCases.Comments.Employee.Comments.Delete;

public class DeleteEmployeeCommentHandler(IRepository<Comment> repository, IRepository<Feedback> feedbackRepository)
  : ICommandHandler<DeleteEmployeeCommentCommand, Result>
{
  public async Task<Result> Handle(DeleteEmployeeCommentCommand request, CancellationToken cancellationToken)
  {
    var feedBackSpec = new FeedbackByLoginId(request.loginId);
    var feedback = await feedbackRepository.FirstOrDefaultAsync(feedBackSpec, cancellationToken);
    if (feedback == null)
    {
      return Result.NotFound("Feedback not found");
    }
    var commentsSpec = new CommentListSpec(feedback.Id,false);
    var comments = await repository.ListAsync(commentsSpec, cancellationToken);

    if (!comments.Any())
    {
      return Result.NotFound("Comment not found");
    }

    await repository.DeleteRangeAsync(comments, cancellationToken);

    return Result.Success();
  }
}
