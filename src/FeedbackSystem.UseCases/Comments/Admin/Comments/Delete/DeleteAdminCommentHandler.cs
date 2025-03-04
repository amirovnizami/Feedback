using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.CommentAggregate.Specification;
using FeedbackSystem.UseCases.Comments.Delete;

namespace FeedbackSystem.UseCases.Comments.Admin.Comments.Delete;

public class DeleteAdminCommentHandler(IRepository<Comment> repository)
  : ICommandHandler<DeleteAdminCommentCommand, Result>
{
  public async Task<Result> Handle(DeleteAdminCommentCommand request, CancellationToken cancellationToken)
  {
    var exisitingComments = new CommentListSpec(request.feedbackId, true);
    var comments = await repository.ListAsync(exisitingComments, cancellationToken);
    
    await repository.DeleteRangeAsync(comments, cancellationToken);
    return Result.Success();
  }
}
