﻿using FeedbackSystem.UseCases.Comments.Delete;

namespace FeedbackSystem.Web.Admin.Comments.Delete;

public class Delete(IMediator _mediatr) : Endpoint<DeleteCommentRequest>
{
  public override void Configure()
  {
    Delete(DeleteCommentRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DeleteCommentRequest req, CancellationToken cancellationToken)
  {
    var command = new DeleteAdminCommentCommand(req.FeedbackId);
    var result = await _mediatr.Send(command, cancellationToken);
    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    }

    ;
  }
}
