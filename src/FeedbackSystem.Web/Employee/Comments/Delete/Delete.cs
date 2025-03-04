using Ardalis.Result.AspNetCore;
using FeedbackSystem.UseCases.Comments.Delete;
using FeedbackSystem.UseCases.Comments.Employee.Comments.Delete;

namespace FeedbackSystem.Web.Employee.Comments.Delete;

public class Delete(IMediator mediatr) : Endpoint<DeleteCommentRequest>
{
  public override void Configure()
  {
    Delete(DeleteCommentRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(DeleteCommentRequest req, CancellationToken cancellationToken)
  {
    var command = new DeleteEmployeeCommentCommand(req.LoginId);
    var result = await mediatr.Send(command, cancellationToken);
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
