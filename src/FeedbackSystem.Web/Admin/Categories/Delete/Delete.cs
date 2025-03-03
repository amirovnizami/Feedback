using FeedbackSystem.UseCases.Categories.Delete;

namespace FeedbackSystem.Web.Categories.Delete;

public class Delete(IMediator _mediator)
  : Endpoint<DeleteCategoryRequest>
{
  public override void Configure()
  {
    Delete(DeleteCategoryRequest.Route);
  }

  public override async Task HandleAsync(
    DeleteCategoryRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeleteCategoryCommand(request.CategoryId);

    var result = await _mediator.Send(command, cancellationToken);

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
    // TODO: Handle other issues as needed
  }
}
