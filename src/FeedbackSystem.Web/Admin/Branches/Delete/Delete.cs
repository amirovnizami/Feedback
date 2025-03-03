using FeedbackSystem.UseCases.Branches.Delete;
using FeedbackSystem.Web.Branches;

namespace FeedbackSystem.Web.Admin.Branches.Delete;

public class Delete(IMediator mediator)
  : Endpoint<DeleteBranchRequest>
{
  public override void Configure()
  {
    Delete(DeleteBranchRequest.Route);
  }

  public override async Task HandleAsync(
    DeleteBranchRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeleteBranchCommand(request.BranchId);

    var result = await mediator.Send(command, cancellationToken);

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
