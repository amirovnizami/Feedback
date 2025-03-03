using FeedbackSystem.UseCases.Categories.Get;
using FeedbackSystem.UseCases.Categories.Update;

namespace FeedbackSystem.Web.Categories.Update;

public class UpdateCategory(IMediator _mediator)
  : Endpoint<UpdateCategoryRequest, UpdateCategoryResponse>
{
  public override void Configure()
  {
    Put(UpdateCategoryRequest.Route);
  }

  public override async Task HandleAsync(UpdateCategoryRequest request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateCategoryCommand(request.CategoryId, request.Name), cancellationToken);
    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetCategoryQuery(request.CategoryId);
    var queryResult = await _mediator.Send(query, cancellationToken);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateCategoryResponse(new CategoryRecord(dto.Id, dto.Name));
      return;
    }
  }
}
