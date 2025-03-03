using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.CommentAggregate.Specifications;
using FeedbackSystem.UseCases.Comments.Delete;

namespace FeedbackSystem.UseCases.Comments.Admin.Comments.Delete;

public class DeleteAdminCommentHandler(IRepository<Comment> repository)
  : ICommandHandler<DeleteAdminCommentCommand, Result>
{
  public async Task<Result> Handle(DeleteAdminCommentCommand request, CancellationToken cancellationToken)
  {
    var comments = new CommentListSpec(request.feedbackId, null);
    if (comments == null)
    {
      return Result.NotFound("Comment not found");
    }

    await repository.DeleteRangeAsync(comments, cancellationToken);
    return Result.Success();
  }
}
