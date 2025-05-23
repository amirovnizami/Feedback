﻿using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.FeedbackAgrregate.Specifications;
using FeedbackSystem.Core.StatusAgrregate;
using FeedbackSystem.UseCases.Security;

namespace FeedbackSystem.UseCases.Comments.Admin.Comments.Create;

public class CreateAdminCommentHandler(IRepository<Comment> repository, IRepository<Feedback> feedbackRepository)
  : ICommandHandler<CreateAdminCommentCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateAdminCommentCommand request, CancellationToken cancellationToken)
  {
    // var id = userContext.MustGetUserId();
    // var commentId = id >= 0 ? (int?)null : 0;
    var feedbackSpecification = new FeedbackByLoginId(request.feedbackId);
    var result = await feedbackRepository.FirstOrDefaultAsync(feedbackSpecification, cancellationToken);
    if (result == null) return Result.NotFound("Feedback not found");

    if (result.StatusId == 1)
    {
      result.StatusId = 4;
      await feedbackRepository.UpdateAsync(result, cancellationToken);
    }

    var newComment = new Comment(request.comment, result.Id, true, request.filename);
    var createdItem = await repository.AddAsync(newComment, cancellationToken);
    return Result.Success(createdItem.Id);
  }
}
